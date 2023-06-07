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
    public partial class DiscsA : ContentPage
    {
        public DiscsA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }

        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetDiscs();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Discs selectedDisc = (Discs)e.SelectedItem;
            DiscPage discPage = new DiscPage();
            discPage.BindingContext = selectedDisc;
            await Navigation.PushAsync(discPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Discs disc = new Discs();
            DiscPage discPage = new DiscPage();
            discPage.BindingContext = disc;
            await Navigation.PushAsync(discPage);
        }
    }
}