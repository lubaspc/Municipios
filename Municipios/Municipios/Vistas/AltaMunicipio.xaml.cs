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
	public partial class AltaMunicipio : ContentPage
	{
		public AltaMunicipio ()
		{
			InitializeComponent ();
		}

        private void GuardarMun_OnClicked(object Sender, EventArgs E)
        {
            if (Verificacion())
            {
                DisplayAlert("Validacion", "Alguno de los campos No esta lleno Revisalo", "Aceptar");
            }
            else
            {
                inserta();
                DisplayAlert("Municipo", "Municipio Dado de alta", "Aceptar");
            }
        
        }

        private async Task inserta()
        {
            var FireHelper = new FireHelper();
            await FireHelper.AddMunicipio(new Modelos.municipio()
            {
                IGECEM = AIGECEM.Text,
                Altitud = ALatitud.Text,
                Cabecera = ACabecera.Text,
                Clima = AClima.Text,
                Latitud = ALatitud.Text,
                Longitud = ALongitud.Text,
                Nombre = ANombre.Text,
                Significado = ASignificado.Text,
                Superficie = ASuperficie.Text,
                Elevacion = AElevacion.IsToggled.ToString(),
                ElevacionAltitud = AEleAltitud.Text,
                Rio = ARio.Text,
                RioLongitud = ALongRio.Text,
                Cuerpo = ACuerpo.IsToggled.ToString(),
                CuerpoCapacidad = ACuerpoCapacidad.Text,
                MasPoblado = APoblacionMax.IsToggled.ToString(),
                Poblacion = APoblacion.Text,
                MasExtensos = AMaxExtensos.IsToggled.ToString(),
                MenosExtensos = AMinExtensos.IsToggled.ToString(),
                MasIndustria = AIndus.IsToggled.ToString()
            });
        }

        public bool Verificacion()
        {
            return String.IsNullOrWhiteSpace(AIGECEM.Text) && String.IsNullOrWhiteSpace(ANombre.Text)
                   && String.IsNullOrWhiteSpace(ASignificado.Text) && String.IsNullOrWhiteSpace(AAltitud.Text)
                   && String.IsNullOrWhiteSpace(ACabecera.Text) && String.IsNullOrWhiteSpace(AClima.Text)
                   && String.IsNullOrWhiteSpace(ALatitud.Text) && String.IsNullOrWhiteSpace(ALongitud.Text)
                   && String.IsNullOrWhiteSpace(ASuperficie.Text) && String.IsNullOrWhiteSpace(AEleAltitud.Text)
                   && String.IsNullOrWhiteSpace(ARio.Text) && String.IsNullOrWhiteSpace(ALongRio.Text)
                   && String.IsNullOrWhiteSpace(ACuerpoCapacidad.Text) && String.IsNullOrWhiteSpace(APoblacion.Text);
        }
    }
}