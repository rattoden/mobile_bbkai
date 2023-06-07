using Microsoft.EntityFrameworkCore;
using mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
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
	public partial class Chet1 : ContentPage
    {
        public List<Raspis> Data1 { get; set; }
        public List<Raspis> Data2 { get; set; }
        public List<Raspis> Data3 { get; set; }
        public List<Raspis> Data4 { get; set; }
        public List<Raspis> Data5 { get; set; }
        public List<Raspis> Data6 { get; set; }
        public string Text { get; set; }
        public Chet1 (string a)
		{
            InitializeComponent ();
            int i = 0;
            Data1 = App.dbContext.GetRaspis11(a, i);
            int b = Data1.Count();
            lv1.HeightRequest = 100 + b * lv1.RowHeight;
            Data2 = App.dbContext.GetRaspis22(a, i);
            int c = Data2.Count();
            lv2.HeightRequest = 100 + c * lv2.RowHeight;
            Data3 = App.dbContext.GetRaspis33(a, i);
            int d = Data3.Count();
            lv3.HeightRequest = 100 + d * lv3.RowHeight;
            Data4 = App.dbContext.GetRaspis44(a, i);
            int e = Data4.Count();
            lv4.HeightRequest = 100 + e * lv4.RowHeight;
            Data5 = App.dbContext.GetRaspis55(a, i);
            int f = Data5.Count();
            lv5.HeightRequest = 100 + f * lv5.RowHeight;
            Data6 = App.dbContext.GetRaspis66(a, i);
            int g = Data6.Count();
            lv6.HeightRequest = 100 + g * lv6.RowHeight;
            Text = "Расписание преподавателя " + a + " (чет)";
            BindingContext = this;

        }
    }
}