using System.Collections.Generic;
using RESTApi.HyperMedia;
using RESTApi.HyperMedia.Abstract;

namespace RESTApi.Data.VO
{
    public class PersonVO : ISupportHyperMedia
    {
        // [JsonPropertyName("code")] customização json
        public long Id {get; set;}
    
        // [JsonPropertyName("name")]
        public string FirstName { get; set; }
        
        // [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        // [JsonIgnore]
        public string Address { get; set; }

        // [JsonPropertyName("sex")]
        public string Gender { get; set; }

        public bool Enable {get; set;}
        public List<HyperMediaLink> Links { get; set;} = new List<HyperMediaLink>();
    }
}