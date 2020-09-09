using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinLayout
{
	

				public class StackPage:ContentPage
    {
		
					public StackPage()
					{
			Label lbl1 = new Label()
			{
				Text = "Esimene",
				TextColor = Color.Red,
				BackgroundColor = Color.Gray,
				FontSize = 24,
				
			
			};
			Label lbl2 = new Label()
			{
				Text = "Teine",
				TextColor = Color.Yellow,
				BackgroundColor = Color.Gray
			};
			Label lbl3 = new Label()
			{
				Text = "Esimene",
				TextColor = Color.Green,
				BackgroundColor = Color.Gray
			};
			StackLayout sl = new StackLayout()
			{
				BackgroundColor=Color.GreenYellow,
				VerticalOptions=LayoutOptions.Center,
				Children = { lbl1, lbl2, lbl3 }
			};
			sl.Spacing = 24;
			
			this.Content = sl;

					}
    }
}
