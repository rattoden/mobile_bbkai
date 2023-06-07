using mobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    public partial class News1 : ContentPage
    {
        public string date_n { get; set; }
        public News1(News news)
        {
            InitializeComponent();
            da.Text = news.date_n;
            za.Text = news.zag;
            tx.Text = news.txt;
            tx1.Text = news.txt1;
            im.Source = news.img;
        }
        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {

        }

    }
}