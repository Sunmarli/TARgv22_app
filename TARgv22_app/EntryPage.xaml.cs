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
    public partial class EntryPage : ContentPage
    {
        Label label;
        Editor editor;
        public EntryPage()
        {
            editor = new Editor
            {
                Placeholder="Sisesta siia tekst",
                BackgroundColor= Color.AntiqueWhite,
                TextColor= Color.Brown
            };
            editor.TextChanged += Editor_TextChanged;
            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.Brown
            };
            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            b.Clicked += B_Clicked;
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { label, editor ,b},
                BackgroundColor = Color.Bisque
            };
            Content = st;
        }
        int i = 0, k=0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            char key=e.NewTextValue?.LastOrDefault() ?? '\0'; //?Count()
            if (key=='A')
            {
                i++;
                label.Text=key.ToString()+": "+i.ToString();
            }
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}