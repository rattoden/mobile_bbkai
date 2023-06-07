using mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Xamarin.Forms.Internals.Profile;

namespace mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dokii : ContentPage
	{
        public Dokii()
        {
            InitializeComponent();
        }

            protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            if (Class1.disc != null && Class1.vid != null)
                lb.Text = Class1.disc.name_d.ToString() + ": " + Class1.vid.name_v.ToString();
            if (Class1.auth_user != null)
                lb1.Text = Class1.auth_user.fio_u.ToString();
            int b = Class1.vid.id_v;
            int c = Class1.disc.id_d;

            List<Doki> products = App.dbContext.GetDoki(b, c);
            int i = products.Count();
            myListView.ItemsSource = products;
            myListView.HeightRequest = i * myListView.RowHeight;

            List<Doki> products1 = App.dbContext.GetDoki1(b, c);
            int y = products1.Count();
            myListView1.ItemsSource = products1;
            myListView1.HeightRequest = y * myListView1.RowHeight;
            if (Class1.auth_user.role_u == 3)
            {
                myListView1.IsVisible = true;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string a = clickedButton.Text.ToString();
            int b = Class1.vid.id_v;
            int c = Class1.disc.id_d;
            await Launcher.OpenAsync(App.dbContext.GetDok(a, b, c));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string a = clickedButton.Text.ToString();
            int b = Class1.vid.id_v;
            int c = Class1.disc.id_d;
            Class1.dok = App.dbContext.GetDok1(a, b, c);
            await Navigation.PushAsync(new AddOtchet());
        }
    }
}