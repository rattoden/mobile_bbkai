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
    public partial class Admin : ContentPage
    {
        public Admin()
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
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewsA());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersA());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DiscsA());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GroupsA());
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UDsA());
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GDsA());
        }
    }
}