using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace ejercicio_PokeAPI.Models
{
    public class PokeLista
    {
        [JsonProperty("count")]
        public long cantidad { get; set; }

        [JsonProperty("next")]
        public Uri siguiente { get; set; }

        [JsonProperty("previous")]
        public object anterior { get; set; }

        [JsonProperty("results")]
        public List<Pokemon> listaPokemones { get; set; }
    }
}
