using System;
using System.Collections.Generic;
using System.Text;

namespace ComandasC.Models
{
    public enum Tipo { platillo, bebida };
    public class Producto
    {
        public int Cantidad { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = "";
        public string Imagen { get; set; } = "";
        public Tipo tipo { get; set; }
        
    }
}
