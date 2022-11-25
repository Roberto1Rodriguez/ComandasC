using ComandasC.Models;
using ComandasC.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ComandasC.ViewModels
{
    public class ComandasViewModel:INotifyPropertyChanged
    {
        ClienteService cliente = new ClienteService();

        public void Lanzar(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public int CantidadT { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AgregarCommand { get; set; }
      public ICommand EnviarCommand { get; set; }
        public List<Producto> Pedidos { get; set; }      
        private Producto producto;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Producto")); }
        }
        public Comanda Comanda { get; set; }
        public ObservableCollection<Producto> Productos { get; set; }
        public List<Producto> platillos { get; set; }
        public List<Producto> bebida { get; set; }
        public ComandasViewModel()
        {
            EnviarCommand = new Command(EnviarComanda);
            Comanda = new Comanda();
            Comanda.Pedidos = new Dictionary<string, Producto>();    
        Producto= new Producto();
            AgregarCommand = new Command(agregarproducto);
            Productos = new ObservableCollection<Producto>
          {
              new Producto
              {
                  Nombre= "Rollo Taiki",
                  Precio=20,
                  Descripcion="Arroz Blanco, aguacate, queso manchego, chile serrano, tocino y carne",
                  Imagen="RolloTaiki.jpg",
                  tipo= Tipo.platillo,
                  Cantidad=1,
              },
              new Producto
              {
                  Nombre="Rollo Dai",
                  Precio=20,
                  Descripcion="Arroz frito, fajita de pollo, queso, aguacate, tampico",
                  Imagen="RolloDai.jpg",
                   tipo= Tipo.platillo,
             Cantidad=1,
              },
              new Producto
              {
                   Nombre="Rollo Sakura",
                  Precio=20,
                  Descripcion="Arroz frito, fajita de pollo, queso, aguacate, tampico",
                  Imagen="RolloSakura.jpg",
                   tipo= Tipo.platillo,
                    Cantidad=1,
        },
               new Producto
              {
                   Nombre="Arroz Yakimeshi",
                  Precio=20,
                  Descripcion="Tazón con arroz frito, sazonado a la plancha con verduras y huevo.",
                  Imagen="arrozY.jpeg",
                   tipo= Tipo.platillo,
                    Cantidad=1,
        },
             new Producto
             {
                 Nombre="Coca Cola",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="cocacola.jpg",
                   tipo= Tipo.bebida,
                    Cantidad=1,
        },
             new Producto
             {
                 Nombre="Pepsi",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="pepsi.jpg",
                   tipo= Tipo.bebida,
                    Cantidad=1,
        },
              new Producto
             {
                 Nombre="Dr.Pepper",
                  Precio=20,
                  Descripcion="600 ml",
                  Imagen="Dr.png",
                   tipo= Tipo.bebida,
                    Cantidad=1,
        }
          };
            platillos = new List<Producto>(Productos.Where(x => x.tipo == Tipo.platillo));
            bebida = new List<Producto>(Productos.Where(x => x.tipo == Tipo.bebida));

        }

        private async void EnviarComanda()
        {

            Comanda.Fecha = DateTime.Now.ToShortTimeString();
            await cliente.Comanda(Comanda);
            Comanda = new Comanda();
            Pedidos = null;
            Lanzar(nameof(Pedidos));
            Lanzar(nameof(Comanda));
            Comanda = new Comanda();
            Comanda.Pedidos = new Dictionary<string, Producto>();

        }
        public void agregarproducto()
        {
            
            if (Comanda.Pedidos.ContainsKey(Producto.Nombre))
            {
                Comanda.Pedidos[Producto.Nombre].Cantidad += 1;
                Comanda.total += Producto.Precio;
               

            }
            else
            {
                Comanda.Pedidos.Add(Producto.Nombre, Producto);
                Comanda.total += Producto.Precio;
                CantidadT += Producto.Cantidad;

               
              
             
            }
            Pedidos = Comanda.Pedidos.Values.ToList();
            Lanzar(nameof(Comanda));
            Lanzar(nameof(Pedidos));
         
        }
        }
       
    }
    

