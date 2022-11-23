using ComandasC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComandasC.Services
{
   public class ClienteService
    {
        HttpClient cliente = new HttpClient();
        public ClienteService()
        {
            cliente.BaseAddress = new Uri("/comanda/");
        }

        public async Task Comanda(Comanda c)
        {
            var json = JsonConvert.SerializeObject(c);
            var response = await cliente.PostAsync("Nueva", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
