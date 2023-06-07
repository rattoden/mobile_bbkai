﻿using mobile.Models;
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
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var group = (Groups)BindingContext;
            if (!String.IsNullOrEmpty(nu.Text))
            {
                App.dbContext.SaveGroup(group);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var news = (Groups)BindingContext;
                App.dbContext.DeleteGroup(news.id_g);
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