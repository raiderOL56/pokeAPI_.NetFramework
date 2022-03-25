using ejercicio_PokeAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace ejercicio_PokeAPI
{
    public class ApiRequest
    {
        public string url { get; set; }
        private int actual = 0;

        public ApiRequest()
        {
            url = "https://pokeapi.co/api/v2/pokemon?limit=10&offset=";
        }

        public PokeLista ObtenerLista()
        {
            var consulta = (HttpWebRequest)WebRequest.Create(url + actual);
            consulta.Method = "GET";
            consulta.ContentType = "aplication/json";
            consulta.Accept = "aplication/json";

            try
            {
                using (WebResponse response = consulta.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (stream == null)
                        {
                            return null;
                        }
                        using (StreamReader lector = new StreamReader(stream))
                        {
                            string responseTexto = lector.ReadToEnd();

                            PokeLista pokeLista = JsonConvert.DeserializeObject<PokeLista>(responseTexto);
                            actual += 10;
                            return pokeLista;
                        }
                    }
                }
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
