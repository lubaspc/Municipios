using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Municipios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class master_home : ContentPage
	{
        public ListView ListView;

        public master_home ()
		{
			InitializeComponent ();

            BindingContext = new Administrador_MasterMasterViewModel();
            ListView = MenuItemsListView;
        }
	}

    class Administrador_MasterMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Administrador_MasterMenuItem> MenuItems { get; set; }

        public Administrador_MasterMasterViewModel()
        {
            MenuItems = new ObservableCollection<Administrador_MasterMenuItem>(new[]
            {
                    new Administrador_MasterMenuItem { Id = 1, Title = "Consulta usuario" ,TargetType =typeof(Vistas.ConsultaUsuario)},
                    new Administrador_MasterMenuItem { Id = 2, Title = "Alta municipio" ,TargetType=typeof(Vistas.AltaMunicipio)},
                    new Administrador_MasterMenuItem { Id = 3, Title = "Consulta municipio", TargetType =typeof(Vistas.ConsultaMunicipio) },
                    new Administrador_MasterMenuItem { Id = 4, Title = "Alta Zona de Riesgo", TargetType =typeof(Vistas.AltaRiesgo) },
                    new Administrador_MasterMenuItem { Id = 5, Title = "Consulta Zona de Riesgo", TargetType =typeof(Vistas.ConsultaRiesgo) },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}