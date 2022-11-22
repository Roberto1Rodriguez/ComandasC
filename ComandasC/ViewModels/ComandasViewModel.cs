using ComandasC.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ComandasC.ViewModels
{
    public class ComandasViewModel
    {
        public Comanda comanda { get; set; }
        public ObservableCollection<Producto> Productos { get; set; }
        public List<Producto> platillos { get; set; }
        public List<Producto> bebida { get; set; }
        public ComandasViewModel()
        {
            comanda = new Comanda();
          
            agregarcommand = new RelayCommand<Producto>(agregarproducto);
            Productos = new ObservableCollection<Producto>
          {
              new Producto
              {
                  Nombre= "Rollo Taiki",
                  Precio=20,
                  Descripcion="Arroz Blanco, aguacate, queso manchego, chile serrano, tocino y carne",
                  Imagen="RolloTaiki.jpg",
                  tipo= Tipo.platillo
              },
              new Producto
              {
                  Nombre="Rollo Dai",
                  Precio=20,
                  Descripcion="Arroz frito, fajita de pollo, queso, aguacate, tampico",
                  Imagen="RolloDai.jpg",
                   tipo= Tipo.platillo
              },
              new Producto
              {
                   Nombre="Rollo Sakura",
                  Precio=20,
                  Descripcion="Arroz frito, fajita de pollo, queso, aguacate, tampico",
                  Imagen="RolloSakura.jpg",
                   tipo= Tipo.platillo
              },
               new Producto
              {
                   Nombre="Arroz Yakimeshi",
                  Precio=20,
                  Descripcion="Tazón con arroz frito, sazonado a la plancha con verduras y huevo.",
                  Imagen="arrozY.jpeg",
                   tipo= Tipo.platillo
              },
             new Producto
             {
                 Nombre="Coca Cola",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="cocacola.jpg",
                   tipo= Tipo.bebida
             },
             new Producto
             {
                 Nombre="Pepsi",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="pepsi.jpg",
                   tipo= Tipo.bebida
             },
              new Producto
             {
                 Nombre="Dr.Pepper",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="Dr.png",
                   tipo= Tipo.bebida
             }
          };
            platillos = new List<Producto>(Productos.Where(x => x.tipo == Tipo.platillo));
            bebida = new List<Producto>(Productos.Where(x => x.tipo == Tipo.bebida));

        }
        public ICommand agregarcommand;
        public void agregarproducto(Producto p)
        {
            if (comanda.Pedidos[p.Nombre]!=null)
            {
                comanda.Pedidos[p.Nombre].Cantidad += 1;
            }

            comanda.Pedidos.Add(p.Nombre,p);
        }
       
    }
    
}
