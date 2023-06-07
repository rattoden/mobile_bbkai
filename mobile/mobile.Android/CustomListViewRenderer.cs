using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.View;
using Xamarin.Forms.Platform.Android;
using mobile.Droid;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using mobile;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]

namespace mobile.Droid
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        public CustomListViewRenderer(Context context) : base(context)
        {
        }   

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement != null)
            {
                Control.ChoiceMode = ChoiceMode.Single;
                Control.SetSelector(Android.Resource.Color.Transparent);
                Control.ItemClick += OnItemClick;
            }
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as Android.Widget.ListView;
            var selectedView = listView.GetChildAt(e.Position);
            selectedView?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}