using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinLayout
{
    public class GridPage:ContentPage
    {
		Button btn;
					public GridPage()
					{
			Grid grid = new Grid
			{
				RowDefinitions=
				{
					new RowDefinition{Height=new GridLength(2,GridUnitType.Star)},
					new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
					new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
				},
				ColumnDefinitions=
				{
					new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
					new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
				}				
			};
			BoxView box00 = new BoxView { Color = Color.FromRgb(255, 0, 0) };
			BoxView box10 = new BoxView { Color = Color.FromRgb(145, 23, 54) };
			BoxView box01 = new BoxView { Color = Color.FromRgb(0, 200, 0) };
			BoxView box11 = new BoxView { Color = Color.FromRgb(6, 0, 200) };
			btn = new Button { Text="Vajuta siia", BorderWidth=5};
			btn.Clicked += Btn_Clicked;
			grid.Children.Add(btn, 0, 0);
			grid.Children.Add(box10, 1, 0);
			grid.Children.Add(box01, 0, 1);
			grid.Children.Add(box11, 1, 1);
			grid.Children.Add(box00, 0, 2);
			Grid.SetColumnSpan(box00, 2);
			Content = grid;
		}
		bool clik = false;
		private void Btn_Clicked(object sender, EventArgs e)
		{
			if (clik)
			{
				btn.Text = "Vajuta siia";
				btn.BackgroundColor = Color.FromRgb(100, 100, 100);
				clik = false;
			}
			else
			{
				btn.Text = "Vajutatud";
				btn.BackgroundColor = Color.FromRgb(200, 100, 100);
				clik = true;
			}
			
		}
	}
}
