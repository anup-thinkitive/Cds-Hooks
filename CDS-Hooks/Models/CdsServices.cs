using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CDS_Hooks.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Services
    {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hook")]
        public string Hook { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("prefetch")]
        public Prefetch Prefetch { get; set; }

        [JsonProperty("usageRequirements")]
        public string UsageRequirements { get; set; }
    }
    public class Prefetch
     {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("patientToGreet")]
         public string PatientToGreet { get; set; }

         [JsonProperty("patient")]   
         public string Patient { get; set; }

         [JsonProperty("medications")]
         public string Medications { get; set; }
     }
    
}
