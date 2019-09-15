using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Municipios.Vistas
{
    [XamlCompilation(xamlCompilationOptions: XamlCompilationOptions.Compile)]
    public partial class ModifcarMunicipios : ContentPage
    {
        public Modelos.municipio municipio = null;
        public ModifcarMunicipios(Modelos.municipio Mun)
        {
            InitializeComponent();
            municipio = Mun;
        }

        private void ModMun_OnClicked(object Sender, EventArgs E)
        {
            if (Verificacion())
            {
                DisplayAlert(title: "Error", message: "Faltan campos x llenar", cancel: "Acetar");
            }
            else
            {
                insertar();
            }
        }

        public async Task insertar()
        {
            var modificacion = new FireHelper();
                await modificacion.UpdateMunicipio(IGECEM: municipio.IGECEM, reemplazo: new Modelos.municipio()
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
                DisplayAlert("Modificado", "Modificado", "Aceptado");
                await Navigation.PushAsync(new Home_admin());
        }


        public bool Verificacion()
        {
            return String.IsNullOrWhiteSpace(value: AIGECEM.Text) && String.IsNullOrWhiteSpace(value: ANombre.Text)
               && String.IsNullOrWhiteSpace(value: ASignificado.Text) && String.IsNullOrWhiteSpace(value: AAltitud.Text)
               && String.IsNullOrWhiteSpace(value: ACabecera.Text) && String.IsNullOrWhiteSpace(value: AClima.Text)
               && String.IsNullOrWhiteSpace(value: ALatitud.Text) && String.IsNullOrWhiteSpace(value: ALongitud.Text)
               && String.IsNullOrWhiteSpace(value: ASuperficie.Text) && String.IsNullOrWhiteSpace(value: AEleAltitud.Text)
               && String.IsNullOrWhiteSpace(value: ARio.Text) && String.IsNullOrWhiteSpace(value: ALongRio.Text)
               && String.IsNullOrWhiteSpace(value: ACuerpoCapacidad.Text) && String.IsNullOrWhiteSpace(value: APoblacion.Text);
        }
    }
}