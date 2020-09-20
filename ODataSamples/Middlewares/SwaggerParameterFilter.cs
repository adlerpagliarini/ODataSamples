﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace ODataSamples.Middlewares
{
    public class SwaggerParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var odataParam = operation.Parameters.SingleOrDefault(x => x.Schema.Reference?.Id != null && x.Schema.Reference.Id.Contains("ODataQueryOptions"));
            if (odataParam != null)
            {
                operation.Parameters.Remove(odataParam);

                var odataParams = new string[] { "$count", "$expand", "$filter", "$orderby", "$select", "$skip", "$top" };
                foreach (var param in odataParams)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = param,
                        In = ParameterLocation.Query,
                        Required = false,
                        Schema = new OpenApiSchema { Type = "String" }
                    });
                }
            }
        }
    }
}
