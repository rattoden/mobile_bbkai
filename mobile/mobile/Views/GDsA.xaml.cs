using mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GDsA : ContentPage
    {
        public GDsA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetGDs();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1.flag2 = 0;
            G_D selectedUser = (G_D)e.SelectedItem;
            Class1.gd = selectedUser;
            await Navigation.PushAsync(new GDPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Class1.flag2 = 1;
            Class1.gd = null;
            await Navigation.PushAsync(new GDPage());
        }
    }
}