using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace BlinkClient.Client;
public class SafeContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
        jsonProperty.Required = Required.Default;
        return jsonProperty;
    }

}

