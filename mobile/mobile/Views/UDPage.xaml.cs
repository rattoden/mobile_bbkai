using mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UDPage : ContentPage
    {
        public ObservableCollection<string> Data { get; set; }
        public ObservableCollection<string> Data1 { get; set; }
        public UDPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            Data = new ObservableCollection<string>();
            var users = App.dbContext.GetUsersT();
            foreach (var user in users)
            {
                Data.Add(user.fio_u);
            }
            Data1 = new ObservableCollection<string>();
            var discs = App.dbContext.GetDiscs();
            foreach (var disc in discs)
            {
                Data1.Add(disc.name_d);
            }
            BindingContext = this;
            if (Class1.flag1 == 0)
            {
                fi.SelectedItem = Class1.ud.fio_u;
                na.SelectedItem = Class1.ud.name_d;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Class1.flag1 == 1)
                {
                    U_D user = new U_D
                    {
                        id_u = App.dbContext.GetUser(fi.SelectedItem.ToString()),
                        id_d = App.dbContext.GetDisc1(na.SelectedItem.ToString())
                    };
                    if (fi.SelectedIndex != -1 && na.SelectedIndex != -1)
                    {
                        App.dbContext.SaveUD(user);
                    }
                }
                else
                {
                    Class1.ud.id_u = App.dbContext.GetUser(fi.SelectedItem.ToString());
                    Class1.ud.id_d = App.dbContext.GetDisc1(na.SelectedItem.ToString());
                    var user = Class1.ud;
                    App.dbContext.SaveUD(user);
                }
            }
            catch { }
            finally
            {
                this.Navigation.PopAsync();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if(Class1.ud != null)
            {
                var user = Class1.ud;
                App.dbContext.DeleteUD(user.id_u_d);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}