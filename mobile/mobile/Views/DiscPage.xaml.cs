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
    public partial class DiscPage : ContentPage
    {
        public DiscPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var disc = (Discs)BindingContext;
            if (!String.IsNullOrEmpty(na.Text))
            {
                App.dbContext.SaveDisc(disc);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var disc = (Discs)BindingContext;
                App.dbContext.DeleteDisc(disc.id_d);
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