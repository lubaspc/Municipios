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
    public partial class Consultor_Home : MasterDetailPage
    {
        public Consultor_Home()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MasterPage_Consultor.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Administrador_MasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage_Consultor.ListView.SelectedItem = null;
        }
    }
}