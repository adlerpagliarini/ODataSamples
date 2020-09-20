using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using ODataSamples.Domain;
using ODataSamples.Extensions;
using System;
using System.Linq;

namespace ODataSamples.Infrastructure.ODataMappings
{
    public class EdmModelConfig
    {
        private static object _thisLockBuilder = new object();
        private static bool _initializedBuilder = false;
        private static object _thisLockEdmModel = new object();
        private static bool _initializedEdmModel = false;

        private static ODataConventionModelBuilder _builder;
        private static IEdmModel _edmModel;

        public static ODataConventionModelBuilder GetEdmModelConvention(IServiceProvider provider)
        {
            lock(_thisLockBuilder)
            {
                if(!_initializedBuilder)
                {
                    _builder = new ODataConventionModelBuilder(provider);
                    _builder.MapODataEntity<Developer>();
                    _builder.MapODataEntity<TaskToDo>();
                    _builder.MapODataEntity<Goal>();
                }
                _initializedBuilder = true;
            }
            return _builder;
        }

        public static IEdmModel GetEdmModel()
        {
            lock (_thisLockEdmModel)
            {
                if (!_initializedEdmModel)
                {
                    _edmModel = _builder.GetEdmModel();
                }
                _initializedEdmModel = true;
            }
            return _edmModel;
        }
    }

    public static class ODataConventionModelBuilderExtensions
    {
        public static void MapODataEntity<TEntity>(this ODataConventionModelBuilder builder)
            where TEntity : Identity<TEntity>
        {
            builder.EntitySet<TEntity>(typeof(TEntity).Name).EntityType.HasKey(e => e.Id).Select().Filter().OrderBy().Expand();

            var structuralTypes = builder.StructuralTypes.First(e => e.ClrType == typeof(TEntity));
            var props = typeof(TEntity).GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType.IsEnum())
                {
                    structuralTypes.AddEnumProperty(prop);
                    builder.AddEnumType(prop.PropertyType);
                }
                else if (!prop.PropertyType.IsNonStringClass() && !prop.PropertyType.IsGenericAndIsEnumerable())
                    structuralTypes.AddProperty(prop);
                else if (prop.PropertyType.IsGenericAndIsEnumerable())
                    structuralTypes.AddNavigationProperty(prop, EdmMultiplicity.Many);
                else if (prop.PropertyType.IsNonStringClass())
                    structuralTypes.AddNavigationProperty(prop, EdmMultiplicity.ZeroOrOne);
                else
                    throw new ArgumentException("Prop info not mapped into OData");
            }
        }

        public static void MapODataDto<Translator>(this ODataConventionModelBuilder builder)
            where Translator : class
        {
            builder.EntitySet<Translator>(typeof(Translator).Name);
        }
    }
}
