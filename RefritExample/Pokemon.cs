using Android.Util;
using Newtonsoft.Json;
using System;

namespace RefitExample
{
    public class Pokemon    {

        private int PokemonID;
        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        public int getPokemonID() {
            string [] tokens = url.Split('/');
            return Int32.Parse(tokens[tokens.Length - 2]);  
        }

    }
}