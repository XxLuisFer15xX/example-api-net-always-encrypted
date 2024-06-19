using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class LanguagesSetup : Attribute, IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema() { Type = "string" }
        });
    }
}