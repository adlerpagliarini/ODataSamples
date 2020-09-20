using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using ODataSamples.Domain;
using ODataSamples.Extensions;
using System;

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
}
