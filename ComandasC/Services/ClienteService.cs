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
            cliente.BaseAddress = new Uri("https://cd50-2806-108e-21-5a7b-7df8-8ac8-ecc1-5193.ngrok.io/Comandas/");
        }

        public async Task Comanda(Comanda c)
        {
            var json = JsonConvert.SerializeObject(c);
            var response = await cliente.PostAsync("Nueva", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
