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
	public partial class OtchetiT : ContentPage
	{
        public OtchetiT()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            if (Class1.disc != null && Class1.vid != null && Class1.dok2 != null)
                lb.Text = Class1.disc.name_d.ToString() + ": " + Class1.vid.name_v.ToString();
            if (Class1.auth_user != null)
                lb1.Text = Class1.auth_user.fio_u.ToString();
            int b = Class1.vid.id_v;
            int c = Class1.disc.id_d;
            myListView.ItemsSource = App.dbContext.GetOtcheti(b, c);
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1.flag3 = 0;
            Doki selectedDok = (Doki)e.SelectedItem;
            Class1.dok1 = selectedDok;
            await Navigation.PushAsync(new DokiPage());
        }
    }
}