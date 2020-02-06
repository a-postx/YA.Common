using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YA.Common
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object sourceObject)
        {
            return JToken.Parse(JsonConvert.SerializeObject(sourceObject)).ToString(Formatting.Indented);
        }
    }
}
