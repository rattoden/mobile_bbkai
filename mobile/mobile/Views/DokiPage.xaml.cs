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
    public partial class DokiPage : ContentPage
    {
        public DokiPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }
        private void ShowNews()
        {
            vi.Text = Class1.vid.name_v;
            di.Text = Class1.disc.name_d;
            if (Class1.flag3 == 0)
            {                
                na.Text = Class1.dok1.name_d;
                ss.Text = Class1.dok1.ssilka_d;
                if (Class1.dok1.flag_d == 0)
                    ot.IsChecked = false;
                else
                    ot.IsChecked = true;
                BindingContext = this;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Class1.flag3 == 1)
                {
                    int i;
                    if (ot.IsChecked == true)
                        i = 1;
                    else
                        i = 0;
                    Doki user = new Doki
                    {
                        id_u = Class1.auth_user.id_u,
                        id_v = Class1.vid.id_v,
                        name_d = na.Text,
                        ssilka_d = ss.Text,
                        flag_d = i,
                        id_di = Class1.disc.id_d
                    };
                    if (!String.IsNullOrEmpty(na.Text) && !String.IsNullOrEmpty(ss.Text))
                    {
                        App.dbContext.SaveDoki(user);
                    }
                }
                else
                {
                    int i;
                    if (ot.IsChecked == true)
                        i = 1;
                    else
                        i = 0;
                    Class1.dok1.name_d = na.Text;
                    Class1.dok1.ssilka_d = ss.Text;
                    Class1.dok1.flag_d = i;
                    var user = Class1.dok1;
                    if (!String.IsNullOrEmpty(na.Text) && !String.IsNullOrEmpty(ss.Text))
                    {
                        App.dbContext.SaveDoki(user);
                    }
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
            if(Class1.dok1 != null)
            {
                var user = Class1.dok1;
                App.dbContext.DeleteDoki(user.id_d);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}