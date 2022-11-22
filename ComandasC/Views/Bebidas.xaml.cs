using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComandasC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bebidas : ContentPage
    {
        public Bebidas()
        {
            InitializeComponent();
            
        }

        private void col2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (col1.SelectedItems.Count == 0)
            {
                agg.IsVisible = false;
            }
            else
            {
                agg.IsVisible = true;

            }

        }
    }
}