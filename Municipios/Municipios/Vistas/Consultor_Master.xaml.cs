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

namespace Municipios.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Consultor_Master : ContentPage
	{
        public ListView ListView;

        public Consultor_Master ()
		{
			InitializeComponent ();
            BindingContext = new Administrador_MasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class Administrador_MasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Administrador_MasterMenuItem> MenuItems { get; set; }

            public Administrador_MasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<Administrador_MasterMenuItem>(new[]
                {
                    new Administrador_MasterMenuItem { Id = 0, Title = "Municipios",TargetType =typeof(Vistas.Consultor_Municipios)  },
                    new Administrador_MasterMenuItem { Id = 1, Title = "Zonas de riesgo" ,TargetType =typeof(Vistas.Consultor_ZonasRiesgo)},
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
}