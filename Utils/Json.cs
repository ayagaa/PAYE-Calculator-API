using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Utils
{
    public static class Json
    {
        private static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public static RootObject ParseApiData<RootObject>(string ApiResult)
        {
            RootObject rootObject;
            try
            {
                rootObject = JsonConvert.DeserializeObject<RootObject>(ApiResult, JsonSerializerSettings);
                return rootObject;
            }
            catch (Exception)
            {
            }
            return default(RootObject);
        }

        public static string SerializeResults<RootObject>(RootObject DataObject)
        {
            return JsonConvert.SerializeObject(DataObject, JsonSerializerSettings);
        }
    }
}
