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
    public partial class GDPage : ContentPage
    {
        public ObservableCollection<string> Data { get; set; }
        public ObservableCollection<string> Data1 { get; set; }
        public GDPage()
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
            var users = App.dbContext.GetGroups();
            foreach (var user in users)
            {
                Data.Add(user.num_g);
            }
            Data1 = new ObservableCollection<string>();
            var discs = App.dbContext.GetDiscs();
            foreach (var disc in discs)
            {
                Data1.Add(disc.name_d);
            }
            BindingContext = this;
            if (Class1.flag2 == 0)
            {
                nu.SelectedItem = Class1.gd.num_g;
                na.SelectedItem = Class1.gd.name_d;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Class1.flag2 == 1)
                {
                    G_D user = new G_D
                    {
                        id_g = App.dbContext.GetGroup(nu.SelectedItem.ToString()),
                        id_d = App.dbContext.GetDisc1(na.SelectedItem.ToString())
                    };
                    if (nu.SelectedIndex != -1 && na.SelectedIndex != -1)
                    {
                        App.dbContext.SaveGD(user);
                    }
                }
                else
                {
                    Class1.gd.id_g = App.dbContext.GetGroup(nu.SelectedItem.ToString());
                    Class1.gd.id_d = App.dbContext.GetDisc1(na.SelectedItem.ToString());
                    var user = Class1.gd;
                    App.dbContext.SaveGD(user);
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
            if(Class1.gd != null)
            {
                var user = Class1.gd;
                App.dbContext.DeleteGD(user.id_g_d);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}