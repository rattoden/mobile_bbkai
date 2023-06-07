using mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public string date_n { get; set; }
        public NewsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            if(Class1.flag != 0)
            {
                NewsPage data = new NewsPage()
                {
                    date_n = DateTime.Now.ToShortDateString().ToString(),
                };
                BindingContext = data;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Class1.flag == 1)
            {
                News news = new News
                {
                    zag = za.Text,
                    date_n = da.Text,
                    img = im.Text,
                    txt = tx.Text,
                    txt1 = tx1.Text
                };
                if (!String.IsNullOrEmpty(za.Text) && !String.IsNullOrEmpty(da.Text) && !String.IsNullOrEmpty(im.Text) && !String.IsNullOrEmpty(tx.Text) && !String.IsNullOrEmpty(tx1.Text))
                {
                    App.dbContext.SaveNews(news);
                }
            }
            else
            {
                var news = (News)BindingContext;
                if (!String.IsNullOrEmpty(za.Text) && !String.IsNullOrEmpty(da.Text) && !String.IsNullOrEmpty(im.Text) && !String.IsNullOrEmpty(tx.Text) && !String.IsNullOrEmpty(tx1.Text))
                {
                    App.dbContext.SaveNews(news);
                }
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var news = (News)BindingContext;
                App.dbContext.DeleteNews(news.id);
            }  
            catch { }
            finally
            {
                this.Navigation.PopAsync();
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}