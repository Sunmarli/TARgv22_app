using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        Frame fr;
        List<Color> colors = new List<Color> { Color.DarkRed, Color.Gold, Color.DarkGreen };
        Button btn;
        List<string> text= new List<string>() { "Sisse", "Valja"};
        StackLayout st= new StackLayout();
        StackLayout vf= new StackLayout();
        StackLayout nd= new StackLayout();
        public Valgusfoor()
        {
            vf.Margin=new Thickness(30);
            for (int i=0; i<3; i++)
            {
                fr = new Frame
                {
                    TabIndex = i,
                    BackgroundColor = colors[i],
                    CornerRadius = 90,
                    HeightRequest = 150,
                    BorderColor = Color.Black

                };
                vf.Children.Add(fr);
            }
            nd.Margin=new Thickness(10);
            nd.HorizontalOptions= LayoutOptions.Center;
            nd.Orientation = StackOrientation.Horizontal;
            for(int i=0; i<2; i++)
            {
                btn = new Button
                {
                    Text = text[i],
                    BackgroundColor = Color.AntiqueWhite,
                    TabIndex = i,
                };
                nd.Children.Add(btn);
                btn.Clicked += Btn_Clicked;
            }
            st.Children.Add(vf);
            st.Children.Add(nd);
            Content= st;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}