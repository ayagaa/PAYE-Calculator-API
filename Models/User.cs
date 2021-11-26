using Google.Cloud.Firestore;
using Newtonsoft.Json;
using PAYE.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Models
{
    [FirestoreData]
    public class User: DbBase
    {
        [FirestoreProperty]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "county")]
        public string County { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }


        public async Task<User> GetUserAsync()
        {
            await Task.Delay(0);
            return new User();
        }

        public async Task<bool> SaveAsync()
        {
            await Task.Delay(0);
            var userRepo = new UserRespository();
            var user = userRepo.Add(this);

            return user != null;
        }
    }
}
