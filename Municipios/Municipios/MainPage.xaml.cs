using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Municipios;
using Xamarin.Forms;
using Municipios.Vistas;

namespace Municipios
{
    public partial class MainPage : ContentPage
    {
        FireHelper firebaseHelper = new FireHelper();

        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            String correo = txtUser.Text;
            var user = await firebaseHelper.GetUser(correo);
            if (user != null)
            {
                String password = txtPass.Text;
                if (password.Equals(user.pass))
                {
                    await DisplayAlert("Success", "Bienvenido " + user.nombre, "OK");
                    if (user.tipo.Equals("admin"))
                    {    
                        await Navigation.PushAsync(new Home_admin());
                    }
                    else {
                        await Navigation.PushAsync(new Consultor_Home());
                    }
                    
                }
                else {
                    await DisplayAlert("Fail", "Usuario o contraseña invalidos", "OK");
                }
               

            }
            else
            {
                await DisplayAlert("Fail", "No se encontro al usuario", "OK");
            }
        }

        private async void BtnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Singin());
        }
    }
}
