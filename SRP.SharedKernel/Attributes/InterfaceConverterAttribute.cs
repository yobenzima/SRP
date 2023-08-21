using System.Text.Json.Serialization;

namespace SRP.SharedKernel.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class InterfaceConverterAttribute : JsonConverterAttribute
{
    public InterfaceConverterAttribute(Type converterType): base(converterType)
    {        
    }
}
