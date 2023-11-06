using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxViewPage : ContentPage
    {
        BoxView box;
        public BoxViewPage()
        {
            box = new BoxView
            {
                Color = Color.FromRgb(0, 0, 0),
                CornerRadius = 15,
                WidthRequest = 100,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { box }
            };
            Content = st;
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            box.WidthRequest = box.Width + 50;
            box.HeightRequest = box.HeightRequest + 50;

            if (box.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 5)
            {
                box.HeightRequest = 100;
                box.WidthRequest = 200;
            }
        }
    }
}