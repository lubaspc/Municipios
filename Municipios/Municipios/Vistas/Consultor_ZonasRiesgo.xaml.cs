using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Municipios.Modelos;

namespace Municipios.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultor_ZonasRiesgo : ContentPage
	{
        ListZonas zonas;
        public Consultor_ZonasRiesgo ()
		{
			InitializeComponent ();
            zonas = new ListZonas();
            ListaZonas.ItemsSource = zonas._zonasr;
        }

        private async void BtnPrueba_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Prueba","Base de datos: "+ zonas._zonasr[0].Desastre,"Ok");
        }

        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            

        }*/
    }
}