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
    public partial class UsersA : ContentPage
    {
        public UsersA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetUsers();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1.flag = 0;
            Users selectedUser = (Users)e.SelectedItem;
            Class1.user = selectedUser;
            await Navigation.PushAsync(new UserPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Class1.flag = 1;
            Class1.user = null;
            await Navigation.PushAsync(new UserPage());
        }
    }
}