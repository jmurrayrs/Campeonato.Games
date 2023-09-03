namespace Campeonato.Application.JsonContracts;

using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class IgnorePropertiesContractResolver
    : DefaultContractResolver
{
    private readonly string[] _propertyNamesToIgnore;

    public IgnorePropertiesContractResolver(params string[] propertyNamesToIgnore)
    {
        _propertyNamesToIgnore = propertyNamesToIgnore;
    }

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty property = base.CreateProperty(member, memberSerialization);

        if (_propertyNamesToIgnore.Contains(property.PropertyName))
        {
            property.ShouldSerialize = _ => false;
        }

        return property;
    }
}

