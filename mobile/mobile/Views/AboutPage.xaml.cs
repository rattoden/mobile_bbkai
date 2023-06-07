using mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bbkai1.db");
            MyDbContext dbHelper = new MyDbContext(dbPath);
            List<News> products = dbHelper.GetNews();
            myListView.ItemsSource = products;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var newsItem = button.BindingContext as News;
            await Navigation.PushAsync(new News1(newsItem));
        }
    }
}