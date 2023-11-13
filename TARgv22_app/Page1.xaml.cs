using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Button = Xamarin.Forms.Button;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    { List<ContentPage> pages = new List<ContentPage>()
            { new EntryPage(),new BoxViewPage(), new TimerPage(), new  DateTimePage(), new StepperSliderPage(),new Valgusfoor()

            };
        List<string> teksts = new List<string>() { "Ava Entry leht", "Ava Box leht", "Ava Timer leht","Ava Datetimer", "Ava StepperSlider", "Ava Valgusfoor" };
        StackLayout st;
        public Page1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.LightGray,
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.DarkRed,
                    TextColor = Color.White
                };

                st.Children.Add(button);
                button.Clicked += Button_Cliked;
            }
            
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }
   
       
        private async void Button_Cliked(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }


    }
}       
