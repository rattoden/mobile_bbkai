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
    public partial class GroupsA : ContentPage
    {
        public GroupsA()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ShowNews();
        }

        private void ShowNews()
        {
            myListView.ItemsSource = App.dbContext.GetGroups();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Groups selectedGroups = (Groups)e.SelectedItem;
            GroupPage groupPage = new GroupPage();
            groupPage.BindingContext = selectedGroups;
            await Navigation.PushAsync(groupPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Groups group = new Groups();
            GroupPage groupPage = new GroupPage();
            groupPage.BindingContext = group;
            await Navigation.PushAsync(groupPage);
        }
    }
}