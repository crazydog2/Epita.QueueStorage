using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Epita.QueueStorage.Gateway.Swagger
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (context.ApiDescription.HttpMethod != "POST")
            {
                return;
            }

            if (operation.RequestBody == null)
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "multipart/form-data", new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Type = "object",
                                    Properties = new Dictionary<string, OpenApiSchema>
                                    {
                                        {
                                            "file", new OpenApiSchema
                                            {
                                                Type = "string",
                                                Format = "binary"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            }

            if (operation.RequestBody.Content == null)
            {
                operation.RequestBody.Content = new Dictionary<string, OpenApiMediaType>();
            }

            if (!operation.RequestBody.Content.TryGetValue("multipart/form-data", out OpenApiMediaType content))
            {
                content = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema()
                };

                operation.RequestBody.Content["multipart/form-data"] = content;
            }

            content.Schema.Properties.Clear();
            content.Encoding.Clear();

            IList<ParameterDescriptor> parameters = context.ApiDescription.ActionDescriptor.Parameters;

            ParameterDescriptor[] formFileParams = (from parameter in parameters
                                                    where parameter.ParameterType.IsAssignableFrom(typeof(IFormFile))
                                                    select parameter).ToArray();

            foreach (ParameterDescriptor formFileParam in formFileParams)
            {
                string argumentName = formFileParam.Name;

                operation.RequestBody.Content["multipart/form-data"].Schema.Properties.Add(argumentName, new OpenApiSchema() { Type = "string", Format = "binary" });
            }
        }
    }
}