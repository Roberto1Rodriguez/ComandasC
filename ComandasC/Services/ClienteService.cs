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
            cliente.BaseAddress = new Uri("https://571d-2806-108e-21-5a7b-b424-8dad-1aee-e0ab.ngrok.io/Comandas/");
        }

        public async Task Comanda(Comanda c)
        {
            var json = JsonConvert.SerializeObject(c);
            var response = await cliente.PostAsync("Nueva", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
