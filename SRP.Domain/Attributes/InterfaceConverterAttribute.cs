﻿using System.Text.Json.Serialization;

namespace SRP.Domain.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
public class InterfaceConverterAttribute : JsonConverterAttribute
{
    public InterfaceConverterAttribute(Type converterType): base(converterType)
    {        
    }
}
