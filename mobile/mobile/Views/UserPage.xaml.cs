using mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public ObservableCollection<string> Data { get; set; }
        public ObservableCollection<string> Data1 { get; set; }
        public UserPage()
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
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bbkai1.db");
            MyDbContext dbHelper = new MyDbContext(dbPath);
            var roles = dbHelper.GetRoles();
            foreach (var role in roles)
            {
                Data.Add(role.name_r);
            }
            Data1 = new ObservableCollection<string>();
            var users = App.dbContext.GetGroups();
            foreach (var user in users)
            {
                Data.Add(user.num_g);
            }
            if (Class1.flag == 0)
            {
                if(Class1.user.role_u == 3)
                {
                    lo.Text = Class1.user.login_u;
                    pa.Text = Class1.user.pass_u;
                    ro.SelectedItem = App.dbContext.GetRole(Class1.user.role_u);
                    fi.Text = Class1.user.fio_u;
                    int a = (int)Class1.user.group_s;
                    gr.SelectedItem = App.dbContext.GetGroup(a);
                }
                else
                {
                    lo.Text = Class1.user.login_u;
                    pa.Text = Class1.user.pass_u;
                    ro.SelectedItem = App.dbContext.GetRole(Class1.user.role_u);
                    fi.Text = Class1.user.fio_u;
                    gr.SelectedIndex = -1;
                }
            }
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ro.SelectedIndex == 2)
            {
                label.IsVisible = true;
                stack.IsVisible = true;
            }
            else
            {
                label.IsVisible = false;
                stack.IsVisible = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Class1.flag == 1)
                {
                    if (ro.SelectedIndex == 2)
                    {
                        int? a = App.dbContext.GetGroup(gr.SelectedItem.ToString());
                        Users user = new Users
                        {
                            login_u = lo.Text,
                            pass_u = pa.Text,
                            role_u = 3,
                            fio_u = fi.Text,
                            group_s = a.Value
                        };
                        if (!String.IsNullOrEmpty(lo.Text) && !String.IsNullOrEmpty(pa.Text) && ro.SelectedIndex != -1 && !String.IsNullOrEmpty(fi.Text) && gr.SelectedIndex != -1)
                        {
                            App.dbContext.SaveUser(user);
                        }
                    }
                    else
                    {
                        Users user = new Users
                        {
                            login_u = lo.Text,
                            pass_u = pa.Text,
                            role_u = ro.SelectedIndex + 1,
                            fio_u = fi.Text,
                            group_s = null
                        };
                        if (!String.IsNullOrEmpty(lo.Text) && !String.IsNullOrEmpty(pa.Text) && ro.SelectedIndex != -1 && !String.IsNullOrEmpty(fi.Text))
                        {
                            App.dbContext.SaveUser(user);
                        }
                    }
                }
                else
                {
                    if (ro.SelectedIndex == 2)
                    {
                        Class1.user.login_u = lo.Text;
                        Class1.user.pass_u = pa.Text;
                        Class1.user.role_u = 3;
                        Class1.user.fio_u = fi.Text;
                        Class1.user.group_s = (int)App.dbContext.GetGroup(gr.SelectedItem.ToString());
                    }
                    else
                    {
                        Class1.user.login_u = lo.Text;
                        Class1.user.pass_u = pa.Text;
                        Class1.user.role_u = ro.SelectedIndex + 1;
                        Class1.user.fio_u = fi.Text;
                        Class1.user.group_s = null;
                    }
                    var user = Class1.user;
                    if (!String.IsNullOrEmpty(lo.Text) && !String.IsNullOrEmpty(pa.Text) && !String.IsNullOrEmpty(fi.Text))
                    {
                        App.dbContext.SaveUser(user);
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
            if(Class1.user != null)
            {
                var user = Class1.user;
                App.dbContext.DeleteUser(user.id_u);
            }
            this.Navigation.PopAsync();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}