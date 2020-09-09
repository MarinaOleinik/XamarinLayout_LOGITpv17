using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinLayout
{
	public class Grid8x8 : ContentPage
	{
		int tapCount = 0;
		BoxView box;
		public Grid8x8()
		{
			Grid grid = new Grid
			{
				RowDefinitions =
							{
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
							},
				ColumnDefinitions =
							{
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
							}
			};
			
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					//r = r + 4;
					//g = g + 4;
					//b = b + 4;
					box = new BoxView { Color = Color.FromRgb(200, 200, 200) };
					grid.Children.Add(box, i, j);
					box.IsEnabled = false;
					var tap = new TapGestureRecognizer();
					tap.Tapped += Tap_Tapped;
					box.GestureRecognizers.Add(tap);
				}
			}
			Content = grid;
		}


		private void Tap_Tapped(object sender, EventArgs e)
		{

			BoxView box = sender as BoxView;
			tapCount++;
			if (tapCount % 2 == 0)
			{
				
				box.Color = Color.Beige;
				box.IsEnabled = false;
			}
			else
			{
				box.Color = Color.Red;
				box.IsEnabled = false;
			}
		}
	}
}




