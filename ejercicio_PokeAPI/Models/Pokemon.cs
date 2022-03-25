using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Drawing;
using System.Net;

namespace ejercicio_PokeAPI.Models
{
    public class Pokemon
    {
        [JsonProperty ("name")]
        public string nombrePokemon { get; set; }
        [JsonProperty("url")]
        public Uri urlPokemon { get; set; }

        public Image GetImage()
        {
            string dir = urlPokemon.ToString();
            dir = dir.Substring(0, dir.Length - 1);
            dir = dir.Substring(dir.LastIndexOf("/"));

            dir = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + dir + ".png";

            var request = WebRequest.Create(dir);

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    return Bitmap.FromStream(stream);
                }
            }
        }
    }
}
