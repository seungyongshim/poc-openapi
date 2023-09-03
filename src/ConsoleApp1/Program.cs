using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;

var document = new OpenApiDocument
{
    Info = null,
    Paths = new()
    {
        ["/pets"] = new()
        {
            Description = "테스트1",
            Operations = new Dictionary<OperationType,  OpenApiOperation>()
            {
                [OperationType.Get] = new()
                {
                    Description = "테스트2",
                    Parameters = new List<OpenApiParameter>()
                    {
                        new()
                        {
                            Required = true,
                            AllowEmptyValue = true,
                            In = ParameterLocation.Header
                        }
                    }
                    
                }
            }
        }
    }
};

using var ms = new MemoryStream();
document.SerializeAsYaml(ms, Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);

ms.Position = 0;

using var sr = new StreamReader(ms);

Console.WriteLine(sr.ReadToEnd());
