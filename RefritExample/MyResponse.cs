

using Newtonsoft.Json;
using System.Collections.Generic;

namespace RefitExample {

    public class MyResponse
    {
        [JsonProperty(PropertyName = "count")]
        public int count { get; set; }
        [JsonProperty(PropertyName = "previous")]
        public object previous { get; set; }
        [JsonProperty(PropertyName = "results")]
        public List<Pokemon> results { get; set; }
        [JsonProperty(PropertyName = "next")]
        public string next { get; set; }

    }


}