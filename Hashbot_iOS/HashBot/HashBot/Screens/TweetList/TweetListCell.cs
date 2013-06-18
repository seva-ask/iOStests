using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Data;
using RestSharp.Contrib;

namespace HashBot.Screens.TweetList
{
	public class TweetListCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TweetListCell");

		private ImageLoader _imageLoader;

		private UIImageView _imageView;

		private UILabel _login;

		private UILabel _text;

		private UILabel _hours;

		private string _imageUrl;

		public TweetListCell () : base (UITableViewCellStyle.Default, Key)
		{
			_imageLoader = new ImageLoader ();

			BackgroundView = new UIImageView(UIImage.FromFile ("Backgrounds/table.png"));
			SelectedBackgroundView = new UIImageView(UIImage.FromFile ("Backgrounds/table_pressed.png"));

			_imageView = new UIImageView ();
			_imageView.Frame = new RectangleF (5, 5, 45, 45);
			ContentView.AddSubview (_imageView);

			_login = new UILabel (new RectangleF(57, 10, 240, 18));
			_login.BackgroundColor = UIColor.Clear;
			_login.Font = UIFont.BoldSystemFontOfSize (17);
			_login.TextColor = UIColor.FromRGB (0x00, 0x00, 0x00);
			_login.Text = "Имя пользователя";
			ContentView.AddSubview (_login);

			_text = new UILabel (new RectangleF(57, 30, 260, 16));
			_text.BackgroundColor = UIColor.Clear;
			_text.Font = UIFont.SystemFontOfSize (13);
			_text.TextColor = UIColor.FromRGB (0x89, 0x89, 0x89);
			_text.Text = "Первых 30 символов";
			ContentView.AddSubview (_text);

			_hours = new UILabel (new RectangleF(300, 15, 20, 12));
			_hours.BackgroundColor = UIColor.Clear;
			_hours.Font = UIFont.SystemFontOfSize (11);
			_hours.TextColor = UIColor.FromRGB (0x89, 0x89, 0x89);
			_hours.Text = "5 ч";
			ContentView.AddSubview (_hours);
		}

		public TweetEntry Tweet
		{
			set
			{
				_login.Text = value.User.Name;
				_text.Text = HttpUtility.HtmlDecode (value.Text).Substring (0, Math.Min(value.Text.Length, 30));
				_hours.Text = ((int)Math.Round(DateTime.Now.Subtract(value.CreatedAt).TotalHours)).ToString() + " ч";
				_imageView.Image = null;
				_imageUrl = value.User.ProfileImageUrl;
				_imageLoader.GetImage (_imageUrl, (url, image) => InvokeOnMainThread(() =>
				{
					if (_imageUrl == url)
					{
						_imageView.Image = image;	
					}
				}));
			}
		}
	}
}

