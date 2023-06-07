using mobile.Models;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Chet : ContentPage
    {
        public List<Raspis> Data1 { get; set; }
        public List<Raspis> Data2 { get; set; }
        public List<Raspis> Data3 { get; set; }
        public List<Raspis> Data4 { get; set; }
        public List<Raspis> Data5 { get; set; }
        public List<Raspis> Data6 { get; set; }
        public string Text { get; set; }
        public Chet (string a)
		{
            InitializeComponent ();
            int i = 0;
            Data1 = App.dbContext.GetRaspis1(a, i);
            int b = Data1.Count();
            lv1.HeightRequest = 100 + b * lv1.RowHeight;
            Data2 = App.dbContext.GetRaspis2(a, i);
            int c = Data2.Count();
            lv2.HeightRequest = 100 + c * lv2.RowHeight;
            Data3 = App.dbContext.GetRaspis3(a, i);
            int d = Data3.Count();
            lv3.HeightRequest = 100 + d * lv3.RowHeight;
            Data4 = App.dbContext.GetRaspis4(a, i);
            int e = Data4.Count();
            lv4.HeightRequest = 100 + e * lv4.RowHeight;
            Data5 = App.dbContext.GetRaspis5(a, i);
            int f = Data5.Count();
            lv5.HeightRequest = 100 + f * lv5.RowHeight;
            Data6 = App.dbContext.GetRaspis6(a, i);
            int g = Data6.Count();
            lv6.HeightRequest = 100 + g * lv6.RowHeight;
            Text = "Расписание группы " + a + " (чет)";
            BindingContext = this;

        }
    }
}