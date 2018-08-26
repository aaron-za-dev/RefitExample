using Newtonsoft.Json;

namespace RefitExample
{
    public class Pokemon    {
        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }
}