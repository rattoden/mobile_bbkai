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
    public partial class AddOtchet : ContentPage
    {
        public AddOtchet()
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
                lb1.Text = Class1.auth_user.fio_u.ToString();
            if (Class1.dok != null)
                lb.Text = Class1.dok.name_d.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Otcheti otchet = new Otcheti
            {
                id_d = Class1.dok.id_d,
                id_u = Class1.auth_user.id_u,
                ssilka = ot.Text,
                date_o = DateTime.Now.ToString()
            };
            if (!String.IsNullOrEmpty(ot.Text))
            {
                App.dbContext.SaveOtchet(otchet);
                DisplayAlert("", "Отчёт отправлен", "ОК");
            }
            this.Navigation.PopAsync();
        }
    }
}