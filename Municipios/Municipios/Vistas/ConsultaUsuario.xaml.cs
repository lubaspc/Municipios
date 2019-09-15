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
	public partial class ConsultaUsuario : ContentPage
	{
        private FireHelper fireHelper;
        public ConsultaUsuario ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            fireHelper = new FireHelper();
            var myresult = await fireHelper.GetAllUsers();
            UsersList.ItemsSource = myresult;

        }

        private void OnItemSelected(object Sender, SelectedItemChangedEventArgs E)
        {
            SiguientePagina((Users) E.SelectedItem);
        }

        private async Task SiguientePagina(Users M)
        {
            //await Navigation.PushAsync();
            var Fire = new FireHelper();
            var bol = await DisplayAlert("Cambiar permiso", "¿Cual es el estado que deseas poner al usuario " + M.nombre+"? Actual: "+M.tipo, "Admin",
                "Consultor");
            if (bol)
            {
                await Fire.UpdateUser(M.correo,new Users()
                {
                    correo = M.correo,
                    nombre = M.nombre,
                    pass = M.pass,
                    tipo = "admin"
                });
            }
            else
            {
                await Fire.UpdateUser(M.correo, new Users()
                {
                    correo = M.correo,
                    nombre = M.nombre,
                    pass = M.pass,
                    tipo = "consultor"
                });
            }
        }
    }
}