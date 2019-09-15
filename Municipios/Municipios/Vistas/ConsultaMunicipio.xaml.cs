using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Municipios;

namespace Municipios.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaMunicipio : ContentPage
    {
        private FireHelper fireHelper;
		public ConsultaMunicipio ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            fireHelper = new FireHelper();
          /* await fireHelper.AddMunicipio(new Modelos.municipio()
            {   IGECEM = "126",
                Altitud = "1",
                Cabecera = "yo",
                Clima = "Tu",
                Latitud = "1",
                Longitud = "0",
                Nombre = "yo",
                Significado = "yo",
                Superficie = "0",
                Elevacion = "s",
                ElevacionAltitud = "0",
                Rio = "0",
                RioLongitud = "0",
                Cuerpo = "0",
                CuerpoCapacidad = "0",
                MasPoblado = "0",
                Poblacion = "0",
                MasExtensos = "0",
                MenosExtensos = "0",
                MasIndustria = "0"
            });*/
            var myresult = await fireHelper.GetAllMun();
            vehicleslist.ItemsSource = myresult;

        }

        private void Vehicleslist_OnItemSelected(object Sender, SelectedItemChangedEventArgs E)
        {
            SiguientePagina((Modelos.municipio)E.SelectedItem);

        }

        private async Task SiguientePagina(Modelos.municipio M)
        {
            await Navigation.PushAsync(new verMunicipio(M));

        }
    }
}