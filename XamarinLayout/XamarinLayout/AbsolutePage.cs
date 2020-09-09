using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinLayout
{
    public class AbsolutePage:ContentPage
    {
					public AbsolutePage()
					{
			AbsoluteLayout al = new AbsoluteLayout();
			BoxView red = new BoxView {BackgroundColor=Color.Red };
			BoxView green = new BoxView { BackgroundColor = Color.Green };
			BoxView grey = new BoxView { BackgroundColor = Color.Gray, CornerRadius=20 };
			BoxView yellow = new BoxView { BackgroundColor = Color.Yellow };

			AbsoluteLayout.SetLayoutBounds(red, new Rectangle(0.27, 0.21, 100, 100));
			AbsoluteLayout.SetLayoutFlags(red, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(green, new Rectangle(0.27, 0.61, 100, 100));
			AbsoluteLayout.SetLayoutFlags(green, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(yellow, new Rectangle(0.27, 0.41, 100, 100));
			AbsoluteLayout.SetLayoutFlags(yellow, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(grey, new Rectangle(0.2, 0.2, 150, 400));
			AbsoluteLayout.SetLayoutFlags(grey, AbsoluteLayoutFlags.PositionProportional);


			TapGestureRecognizer tap = new TapGestureRecognizer();
			tap.Tapped += (sender, e) =>
			{
				red.IsVisible = false;
			};
			grey.GestureRecognizers.Add(tap);

			//al.Children.Add(
			//	new Label
			//	{
			//		Text="Pealkiri",
			//		TextColor = Color.Yellow,
			//		BackgroundColor = Color.Lavender,
			//		FontSize =Device.GetNamedSize(NamedSize.Large,typeof(Label))
			//	},
			//		new Rectangle(100,100,150,60)
			//	);
			//al.Children.Add(
			//	new Label
			//	{
			//		Text = "Veel üks Pealkiri",
			//		TextColor = Color.Green,
			//		BackgroundColor = Color.Lavender,
			//		FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			//	},
			//		new Point(100, 200)
			//	);
			al.Children.Add(grey);
			al.Children.Add(red);
			al.Children.Add(yellow);
			al.Children.Add(green);
			Content = al;
		}
    }
}
