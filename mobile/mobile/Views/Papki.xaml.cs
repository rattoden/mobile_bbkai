using mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Papki : ContentPage
	{
        public Papki()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            if (Class1.disc != null)
                lb.Text = Class1.disc.name_d.ToString();
            if (Class1.auth_user != null)
                lb1.Text = Class1.auth_user.fio_u.ToString();
            List<Vidi> products = App.dbContext.GetVidi();
            myListView.ItemsSource = products;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Class1.auth_user.role_u == 2)
            {
                Button clickedButton = (Button)sender;
                string a = clickedButton.Text.ToString();
                Class1.vid = App.dbContext.GetVid(a);
                Navigation.PushAsync(new DokiiT1());
            }
            else if(Class1.auth_user.role_u == 3)
            {
                Button clickedButton = (Button)sender;
                string a = clickedButton.Text.ToString();
                Class1.vid = App.dbContext.GetVid(a);
                Navigation.PushAsync(new Dokii());
            }
        }
    }
}