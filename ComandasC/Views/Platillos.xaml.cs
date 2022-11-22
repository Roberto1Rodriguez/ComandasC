using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComandasC.Models;
using ComandasC.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComandasC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Platillos : ContentPage
    {
        public Platillos()
        {
            InitializeComponent();
          
        }

        private void col_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(col.SelectedItems.Count==0)
            {
                agg.IsVisible = false;
            }
            else
            {
                agg.IsVisible = true;

            }
       
        }

        private void agg_Clicked(object sender, EventArgs e)
        {

        }
    }
}