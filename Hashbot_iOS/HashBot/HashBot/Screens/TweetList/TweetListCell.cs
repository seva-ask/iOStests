using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot.Screens.TweetList
{
	public class TweetListCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TweetListCell");

		public TweetListCell () : base (UITableViewCellStyle.Default, Key)
		{
			BackgroundView = new UIImageView(UIImage.FromFile ("Backgrounds/table.png"));
			SelectedBackgroundView = new UIImageView(UIImage.FromFile ("Backgrounds/table_pressed.png"));

			var imageView = new UIImageView (UIImage.FromFile ("Icons/Icon.png"));
			imageView.Frame = new RectangleF (5, 5, 45, 45);
			ContentView.AddSubview (imageView);

			var login = new UILabel (new RectangleF(57, 10, 240, 18));
			login.BackgroundColor = UIColor.Clear;
			login.Font = UIFont.BoldSystemFontOfSize (17);
			login.TextColor = UIColor.FromRGB (0x00, 0x00, 0x00);
			login.Text = "Имя пользователя";
			ContentView.AddSubview (login);

			var text = new UILabel (new RectangleF(57, 30, 260, 16));
			text.BackgroundColor = UIColor.Clear;
			text.Font = UIFont.SystemFontOfSize (13);
			text.TextColor = UIColor.FromRGB (0x89, 0x89, 0x89);
			text.Text = "Первых 30 символов";
			ContentView.AddSubview (text);

			var hours = new UILabel (new RectangleF(300, 15, 20, 12));
			hours.BackgroundColor = UIColor.Clear;
			hours.Font = UIFont.SystemFontOfSize (11);
			hours.TextColor = UIColor.FromRGB (0x89, 0x89, 0x89);
			hours.Text = "5 ч";
			ContentView.AddSubview (hours);
		}
	}
}

