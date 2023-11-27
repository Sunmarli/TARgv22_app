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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        Button btn, btn2, btn3, btn4;
        StackLayout st;
        Label lb;
        Entry ent;
        List<string> lehed = new List<string>() { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.ee" };
        //string[] lehed = new string[4] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.google.ee" };
        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Google");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView
            { };
            ent = new Entry
            {
                Text = "https://",
            };
            ent.Completed += Ent_Completed;
            btn = new Button
            {
                Text = "Uus webilehed",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };
            btn2 = new Button
            {
                Text = "kodu",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };
            btn3 = new Button
            {
                Text = "<-",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start,

            };
            btn4 = new Button
            {
                Text = "->",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            webView.GestureRecognizers.Add(swipe);
            btn2.Clicked += Btn2_Clicked;
            btn.Clicked += Btn_Clicked;
            btn3.Clicked += Btn3_Clicked;
            btn4.Clicked += Btn4_Clicked;

            st = new StackLayout { Children = { ent, picker, btn, btn2, btn3, btn4 } };
            //sb = new StackLayout { Children = { btn2 } };
            Content = st;
            //Content = sb;
        }

       
    }
}