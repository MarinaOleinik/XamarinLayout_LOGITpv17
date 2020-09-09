using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinLayout
{
	public class Grid3x3 : ContentPage
	{
		private Label lbly;
		private Button btn_new_game;
		private string win;
		private bool tap;
		public string[] arr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
		private string arrayTekst;
		int tapCount = 0;
		Grid grid_image, grid_nupp;
		StackLayout sl;
		private string t;

		public Grid3x3()
		{
			
			New_game();
		}
		public void New_game()
		{
			//tap = false;
			Choice();
			//DependencyService.Get<IAudio>().PlayAudioFile("muz.mp3");
			tapCount = 0;
			for (int i = 0; i < 10; i++)
			{
				arr[i] = i.ToString();// { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			}		
			win = string.Empty;
			int jrknr = 0;
			arrayTekst = string.Join(",", arr);
            grid_image = new Grid
            { BackgroundColor = Color.FromRgb(122, 122, 122),
				RowDefinitions =
							{
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
								new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},							
							},
				ColumnDefinitions =
							{
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
								new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
							}			
			};
			grid_nupp = new Grid { HeightRequest=100, RowSpacing = 10, ColumnSpacing = 10 };		
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Image img = new Image { Source = "fiksiki", StyleId = (++jrknr).ToString() };
					grid_image.Children.Add(img, i, j);
					var tap = new TapGestureRecognizer();
					tap.Tapped += Tap_Tapped;
					img.GestureRecognizers.Add(tap);
				}					
			}
			lbly = new Label { Text = "", FontSize=20,TextColor=Color.FromRgb(255,20,100)};
			btn_new_game = new Button { Text = "Новая игра" };
			btn_new_game.Clicked += Btn_new_game_Clicked;
			grid_nupp.Children.Add(btn_new_game, 0, 0);
			grid_nupp.Children.Add(lbly, 1, 0);
			lbly.Text = "Ход Нолика";
			sl =new StackLayout
			{
				Children = { grid_nupp,  grid_image }
			};
			Content =sl ;
		}
		private async void Choice()
		{
			var player = await DisplayActionSheet("Кто ходит первым?", "Все равно", "Я", "Симка", "Нолик");
			if (player== "Симка")
			{
				tap = true;
				lbly.Text = "Ход Симки" ;
			}
			else
			{
				tap = false;
				lbly.Text = "Ход Нолика";
			}
		}
		private void Btn_new_game_Clicked(object sender, EventArgs e)
		{
			New_game();
		}	
		private void Tap_Tapped(object sender, EventArgs e)
		{
			tapCount++;
			lbly.Text="";		
			Image img = sender as Image;		
			if (tap)
			{
				img.Source = "simka";
				tap = false;
				img.IsEnabled = false;				
				arr[int.Parse(img.StyleId)] = "simka";
				lbly.Text = "Ход Нолика";
			}
			else
			{
				img.Source = "nolik";
				tap = true;
				img.IsEnabled = false;
				arr[int.Parse(img.StyleId)] = "nolik";
				lbly.Text = "Ход Симки";
			}

			win = CheckWin();
			arrayTekst = string.Join(",", arr);
			//lbly.Text = arrayTekst;
			if (win ==  "simka")
			{
				//lbly.Text ="Выиграла Симка";
				grid_image.IsEnabled = false;
				lbly.Text = "";
				More_game();
			}
			else if (win == "nolik")
			{
				//lbly.Text = "Выиграл Нолик";
				
				grid_image.IsEnabled = false;
				lbly.Text = "";
				More_game();
			}
			else if (tapCount==8)
			{
				More_game();
				lbly.Text = "";
			}
		}
		private async void More_game()
		{if (win=="simka")
			{
				t = "a Симка";
			}
		else if (win=="nolik")
			{
				t = " Нолик";
			}
			else
			{
				t = " никто";
			}
			await DisplayAlert("Победа!", "Выиграл"+t.ToString(), "ОK");
			bool result= await DisplayAlert("Новая игра!", "Играем еще?", "Да", "Нет");
			if (result)
			{
				New_game();
			}
		}

		private string CheckWin()
		{			
			if (arr[1] == arr[2] && arr[2] == arr[3])//1=2=3
			{
				return arr[1];
			}
			else if (arr[4] == arr[5] && arr[5] == arr[6])//456
			{
				return arr[4];
			}
			else if (arr[7] == arr[8] && arr[8] == arr[9])//789
			{
				return arr[7];
			}
			else if (arr[1] == arr[4] && arr[4] == arr[7])//147
			{
				return arr[1];
			}
			else if (arr[2] == arr[5] && arr[5] == arr[8])//258
			{
				return arr[2];
			}
			else if (arr[3] == arr[6] && arr[6] == arr[9])//369
			{
				return arr[3];
			}
			else if (arr[1] == arr[5] && arr[5] == arr[9])
			{
				return arr[1];
			}
			else if (arr[3] == arr[5] && arr[5] == arr[7])
			{
				return arr[3];
			}
			else
			{
				return string.Empty;
			}			
		}
	}
}
