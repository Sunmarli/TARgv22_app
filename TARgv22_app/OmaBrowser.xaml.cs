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
    public partial class OmaBrowser : ContentPage
    {

        Picker picker;
        WebView webView;
        StackLayout st;
        Entry addressBar;
        Button backButton;
        Button nextButton;
        Frame frame;
        string[] lehed = new string[3] { "https://tahvel.edu.ee", "https://moodle.edu.ee/", "https://www.err.ee/" };
        int currentIndex = 0;

        public OmaBrowser()
        {
            picker = new Picker
            {
                Title = "Vebilehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("Err");
            
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            //To ensures that webView is not null before any actual navigation or content loading occurs.
            //To establishe a starting point for the WebView object.
            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right | SwipeDirection.Left;
            //Creating new instance
            frame = new Frame
            {
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,

                // Height 20 units
                HeightRequest = 20,

                //Width 400 units
                WidthRequest = 400,

                //aligned to the top of its container.
                VerticalOptions = LayoutOptions.Start,

                // centered horizontally and expand to fill available space
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true,
            };
            //new instance of button
            backButton = new Button
            {
                Text = "Back",
                //1.Command property is set to a new instance of the Command class
                //2. command is initialized with a lambda expression () => NavigateBack().
                //when the button is clicked, the NavigateBack() method will be executed.
                Command = new Command(() => NavigateBack())
            };

            nextButton = new Button
            {
                Text = "Next",
                Command = new Command(() => NavigateNext())
            };




            //new instance of the Entry class assigned to the addressBar variable
            addressBar = new Entry
            {
                Placeholder = "Enter URL",

                //ReturnType.Go, which indicates that pressing "Return"
                //or "Enter" on the keyboard should trigger a specific action
                ReturnType = ReturnType.Go,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            addressBar.Completed += AddressBar_Completed; ;

            //Children property with a collection of UI elements, including picker,
            //addressBar, backButton, and nextButton
            st = new StackLayout { Children = { picker, addressBar, backButton, nextButton } };

            Button addButton = new Button
            {
                Text = "Add Page",

                //OpenAddPagePopup method should be executed when the button is clicked.
                Command = new Command(OpenAddPagePopup)
            };

            st.Children.Add(addButton);

            frame.GestureRecognizers.Add(swipe);

            //layout of the entire page
            Content = st;
        }

        private void AddressBar_Completed(object sender, EventArgs e)
        {
            //It calls the Navigate method, passing the text entered in the addressBar
            Navigate(addressBar.Text);
        }

        //method is responsible for navigating to the previous web page 
        private void NavigateBack()
        {
            //To decrement the currentIndex variable, ensuring it doesn't go below 0
            currentIndex = Math.Max(0, currentIndex - 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }

        // //method is responsible for navigating to the next web page 
        private void NavigateNext()
        {
            //To ensure that currentIndex doesn't go beyond the last index of the lehed array.
            currentIndex = Math.Min(lehed.Length - 1, currentIndex + 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }
        private void Navigate(string url)
        {
            //to get the text entered into the address bar
            string enteredUrl = addressBar.Text;

            //If the webView is not null, it removes the existing WebView from the children of the st
            //replacing the current WebView
            if (webView != null)
            {
                st.Children.Remove(webView);
            }

            webView = new WebView
            {
                //1.Source property of the WebView determines what content the WebView should display
                //2. a new instance of UrlWebViewSource is created and assigned to the Source
                //3.UrlWebViewSource is a type in Xamarin.Forms used for loading web content
                //4. Url = enteredUrl, it specifies that the content of the WebView should be
                //loaded from the URL provided in the enteredUrl
                Source = new UrlWebViewSource { Url = enteredUrl },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            st.Children.Add(webView);
        }


        //To track of the index of the current URL
        int ind = 0;

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            //URL from the lehed array at the current index [ind]
            webView.Source = new UrlWebViewSource { Url = lehed[ind] };

            //To increment the value of ind after updating the WebView source
            ind++;

            //To check if ind has reached the end of the array
            if (ind == lehed.Length)
            {
                //if the end of the array is reached, the index is reset to 0 to create a looping effect
                ind = 0;
            }
        }


        //1. It is called when the user selects a different item in the Picker.
        //2. It calls the NavigateToPage method and passes the index of the selected
        //item (picker.SelectedIndex) as an argument.
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            NavigateToPage(picker.SelectedIndex);
        }

        //navigating to the web page associated with the selected item in the Picker
        private void NavigateToPage(int index)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                //1. UrlWebViewSource is a Xamarin.Forms class that represents the source of a WebView based on a URL
                //{} инициализатор объекта, что позволяет задать свойства вновь созданного объекта
                //2. Inside the object initializer, it sets the Url property of the UrlWebViewSource to a specific URL
                //3. lehed[picker.SelectedIndex] retrieves the URL from an array (lehed) based on the selected index.
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        //asynchronous method doesn't return a value.
        private async void OpenAddPagePopup()
        {
            string newPage = await InputPrompt("Add Page", "Enter URL:");

            //If the entered URL is not empty or null, it appends the new URL to the lehed array and
            //updates the items in the picker control by adding a new item labeled "New Page."
            if (!string.IsNullOrEmpty(newPage))
            {
                lehed = lehed.Concat(new[] { newPage }).ToArray();
                picker.Items.Add("New Page");
            }
        }
        private async Task<string> InputPrompt(string title, string message)
        {
            return await DisplayPromptAsync(title, message);
        }
    }
}