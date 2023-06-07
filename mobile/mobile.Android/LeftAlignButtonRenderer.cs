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
using mobile.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomButton), typeof(LeftAlignButtonRenderer))]
namespace mobile.Droid.Renderers
{
    public class LeftAlignButtonRenderer : ButtonRenderer
    {
        public LeftAlignButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Align the text to the left side
                Control.Gravity = Android.Views.GravityFlags.Left;
                Control.SetAllCaps(false);
            }
        }
    }
}