using System;
using System.Collections.Generic;
using System.Text;

namespace ComandasC.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        public Dictionary<string, Producto> Pedidos { get; set; }

        public decimal total { get; set; }

        public string Fecha { get; set; }
        public string Mesa { get; set; }    
    }
}
