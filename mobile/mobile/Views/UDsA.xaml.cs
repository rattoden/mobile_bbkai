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
    public partial class UDsA : ContentPage
    {
        public UDsA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetUDs();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1.flag1 = 0;
            U_D selectedUser = (U_D)e.SelectedItem;
            Class1.ud = selectedUser;
            await Navigation.PushAsync(new UDPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Class1.flag1 = 1;
            Class1.ud = null;
            await Navigation.PushAsync(new UDPage());
        }
    }
}