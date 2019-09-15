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
    public partial class verMunicipio : ContentPage
    {
        public Modelos.municipio Mun = null;
        public verMunicipio(Modelos.municipio M)
        {
            InitializeComponent();
            Mun = M;
            var label = new Label {Text = "Nombre: "+Mun.Nombre,  FontSize = 30, HorizontalOptions = LayoutOptions.CenterAndExpand};
            var label1 = new Label { Text = "Significado: " + Mun.Significado, FontSize = 30 };
            var label2= new Label { Text = "Cabecera: " + Mun.Cabecera, FontSize = 30 };
            var label3 = new Label { Text = "IGECEM: " + Mun.IGECEM, FontSize = 30 };
            var label4 = new Label { Text = "Cima: " + Mun.Clima, FontSize = 30 };
            var label5 = new Label { Text = "Superficie: " + Mun.Superficie, FontSize = 30 };
            var label6 = new Label { Text = "Elevacion: " + Mun.Elevacion, FontSize = 30 };
            var label7 = new Label { Text = "Altitudo de Elevacion: " + Mun.ElevacionAltitud, FontSize = 30 };
            var label8 = new Label { Text = "Rio: " + Mun.Rio, FontSize = 30 };
            var label9 = new Label { Text = "Rio Tamaño: " + Mun.RioLongitud, FontSize = 30 };
            var label10 = new Label { Text = "Cuerpo: " + Mun.Cuerpo, FontSize = 30 };
            var label11 = new Label { Text = "Capacidad del Cuerpo: " + Mun.CuerpoCapacidad, FontSize = 30 };
            var label12 = new Label { Text = "Mas Poblacion: " + Mun.MasPoblado, FontSize = 30 };
            var label13 = new Label { Text = "Mas Extenso: " + Mun.MasExtensos, FontSize = 30 };
            var label14 = new Label { Text = "Menos Extenso: " + Mun.MenosExtensos, FontSize = 30 };
            var label15 = new Label { Text = "Mas Industrial: " + Mun.MasIndustria, FontSize = 30 };
            var label16 = new Label { Text = "Longitud: " + Mun.Longitud, FontSize = 30 };
            var label17 = new Label { Text = "Latitud: " + Mun.Latitud, FontSize = 30 };
            Stack.Children.Add(label);
            Stack.Children.Add(label1);
            Stack.Children.Add(label2);
            Stack.Children.Add(label3);
            Stack.Children.Add(label4);
            Stack.Children.Add(label5);
            Stack.Children.Add(label6);
            Stack.Children.Add(label7);
            Stack.Children.Add(label8);
            Stack.Children.Add(label9);
            Stack.Children.Add(label10);
            Stack.Children.Add(label11);
            Stack.Children.Add(label12);
            Stack.Children.Add(label13);
            Stack.Children.Add(label14);
            Stack.Children.Add(label15);
            Stack.Children.Add(label16);
            Stack.Children.Add(label17);
            Stack.Padding= new Thickness(30,20);


        }

        private void VModificar_OnClicked(object Sender, EventArgs E)
        {
            SiguientePagina();
        }

        public async Task SiguientePagina()
        {
            await Navigation.PushAsync(new ModifcarMunicipios(Mun));
        }

        private  void VEliminar_OnClicked(object Sender, EventArgs E)
        {
            dialog();
        }

        private async void dialog()
        {
           var bol= await DisplayAlert("Eliminar Registro", "Estas seguro de elimanr el Municipio " + Mun.Nombre, "Elimniar",
                "Cancelar");
            if (bol)
            {
                var delet=new FireHelper();
                await delet.DeleteMunicipio(Mun.IGECEM);
            }
        }
    }
}