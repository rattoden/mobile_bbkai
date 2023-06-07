using mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Xamarin.Forms.Shapes;
using Path = System.IO.Path;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Disc : ContentPage
    {
        public Disc()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        { 
            ShowNews();
        }
        private void ShowNews()
        {
            if (Class1.auth_user != null)
                lb.Text = Class1.auth_user.fio_u.ToString();
            if (Class1.auth_user.role_u == 3)
            {
                int a = (int)Class1.auth_user.group_s;
                List<G_D> products = App.dbContext.GetDiscs(a);
                myListView.ItemsSource = products;
            }
            else if (Class1.auth_user.role_u == 2)
            {
                int a = Class1.auth_user.id_u;
                List<U_D> products = App.dbContext.GetDiscsT(a);
                myListView.ItemsSource = products;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string a = clickedButton.Text.ToString();
            Class1.disc = App.dbContext.GetDisc(a);
            Navigation.PushAsync(new Papki());
        }
    }
}