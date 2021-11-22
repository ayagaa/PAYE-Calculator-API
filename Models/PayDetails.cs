using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.Models
{
    [FirestoreData]
    public class PayDetails : DbBase
    {
        [FirestoreProperty]
        [JsonProperty(PropertyName = "phoneNumber")]
        public double PhoneNumber { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "grossPay")]
        public double GrossPay { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "taxableIncome")]
        public double TaxableIncome { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "taxBeforeRelief")]
        public double TaxBeforeRelief { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "paye")]
        public double PAYE { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "personalRelief")]
        public double PersonalRelief { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "nssf")]
        public double NSSF { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "nhif")]
        public double NHIF { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "netPay")]
        public double NetPay { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "payMonth")]
        public string PayMonth { get; set; }
        [FirestoreProperty]
        [JsonProperty(PropertyName = "payYear")]
        public int PayYear { get; set; }
    }
}
