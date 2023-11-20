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
    public partial class FrameGridPage : ContentPage
    {
        Grid grid;
        Random rnd = new Random();
        Label label;

        public FrameGridPage()
        {
            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button
                    {
                        BorderColor = Color.White,
                        CornerRadius = 10,
                        BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)),
                        Text = $"{i}, {j}",
                    };

                    grid.Children.Add(button, i, j);
                    button.Clicked += OnButtonClicked;
                }
            }

            label = new Label { Text = "Text", BackgroundColor = Color.AliceBlue };
            grid.Children.Add(label, 0, 3);
            Grid.SetColumnSpan(label, 2);

            Content = grid;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundColor = Color.Red;

            label.Text = button.Text;
        }
    }
}
