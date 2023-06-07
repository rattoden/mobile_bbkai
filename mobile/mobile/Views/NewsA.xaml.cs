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
    public partial class NewsA : ContentPage
    {
        public NewsA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }

        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetNews();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Class1.flag = 0;
            News selectedNews = (News)e.SelectedItem;
            NewsPage newsPage = new NewsPage();
            newsPage.BindingContext = selectedNews;
            await Navigation.PushAsync(newsPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Class1.flag = 1;
            News book = new News();
            NewsPage newsPage = new NewsPage();
            newsPage.BindingContext = book;
            await Navigation.PushAsync(newsPage);
        }
    }
}