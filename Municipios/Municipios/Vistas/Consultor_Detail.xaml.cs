using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Municipios.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultor_Detail : ContentPage
	{
		public Consultor_Detail ()
		{
			InitializeComponent ();
		}

        private async void BtnMunicipios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consultor_Municipios());
        }

        private async void BtnZonasRiesgo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consultor_ZonasRiesgo());
        }
    }
}