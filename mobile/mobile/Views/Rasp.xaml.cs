using mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rasp : ContentPage
	{
        public ObservableCollection<string> Data { get; set; }
        public ObservableCollection<string> Data1 { get; set; }
        public Rasp()
        {
            InitializeComponent();
            Data = new ObservableCollection<string>();
            var users = App.dbContext.GetGroups();
            foreach (var user in users)
            {
                Data.Add(user.num_g);
            }
            Data1 = new ObservableCollection<string>();
            var users1 = App.dbContext.GetUsers1();
            foreach (var user in users1)
            {
                Data1.Add(user.fio_u);
            }
            BindingContext = this;
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex != -1)
            {
                chet.IsEnabled = true;
                nechet.IsEnabled = true;
            }
            else
            {
                chet.IsEnabled = false;
                nechet.IsEnabled = false;
            }
        }

        private void chet_Clicked(object sender, EventArgs e)
        {
            string a = picker.SelectedItem.ToString();
            Navigation.PushAsync(new Chet(a));
        }
        private void nechet_Clicked(object sender, EventArgs e)
        {
            string a = picker.SelectedItem.ToString();
            Navigation.PushAsync(new NeChet(a));
        }
        private void chet1_Clicked(object sender, EventArgs e)
        {
            string a = picker1.SelectedItem.ToString();
            Navigation.PushAsync(new Chet1(a));
        }

        private void nechet1_Clicked(object sender, EventArgs e)
        {
            string a = picker1.SelectedItem.ToString();
            Navigation.PushAsync(new NeChet1(a));
        }

        private void picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker1.SelectedIndex != -1)
            {
                chet1.IsEnabled = true;
                nechet1.IsEnabled = true;
            }
            else
            {
                chet1.IsEnabled = false;
                nechet1.IsEnabled = false;
            }
        }
    }
}