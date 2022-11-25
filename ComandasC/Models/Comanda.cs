using System;
using System.Collections.Generic;
using System.Text;

namespace ComandasC.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        public Dictionary<string, Producto> Pedidos { get; set; }

        public decimal Total { get; set; }

        public string Hora { get; set; } 
        public string Mesa { get; set; }    
        public string Notas { get; set; }
     
    }
}
