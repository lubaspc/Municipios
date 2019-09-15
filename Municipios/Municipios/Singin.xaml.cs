using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Municipios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Singin : ContentPage
	{
        FireHelper firebaseHelper = new FireHelper();

        public Singin ()
		{
			InitializeComponent ();
		}


        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            String correo = txtCorreo.Text;
            String nombre = txtNombre.Text;
            String pass = txtContraseña.Text;

            if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(pass))
            {
                await firebaseHelper.AddUser(correo, nombre, pass, "consultor");
                txtCorreo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtContraseña.Text = string.Empty;
                await DisplayAlert("Success", "Has sido registrado con exito", "OK");
            }
            else
            {
                await DisplayAlert("Fail", "Rellene todos los campos para poder continuar", "OK");
            }


        }

        private async void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "¿Desea cancelar su solicitud?", "Si", "No");

            if (res)
            {
                txtCorreo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtContraseña.Text = string.Empty;
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}