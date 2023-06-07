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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = App.dbContext.GetUsers().FirstOrDefault(u => u.login_u == log.Text && u.pass_u == pas.Text);
            if (user != null)
            {
                Class1.auth_user = user;
                if(Class1.auth_user.role_u != 1)
                {
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                }
                else
                {
                    await Navigation.PushAsync(new Admin());
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }
        }
    }
}