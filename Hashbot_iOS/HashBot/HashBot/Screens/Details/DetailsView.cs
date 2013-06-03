using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace HashBot.Screens.Details
{
	public class DetailsView : UIView
	{
		public DetailsView ()
		{
			var bg = new UIImageView(UIImage.FromFile ("Tweet/bg.png"));
			AddSubview (bg);

			var image = new UIImageView (UIImage.FromFile ("Icons/icon.png"));
			image.Frame = new RectangleF (20, 30, 64, 64);
			AddSubview (image);

			var author = new UILabel (new RectangleF(100, 50, 280, 300));
			author.TextColor = UIColor.FromRGB (0x44, 0x64, 0x8f);
			author.Font = UIFont.BoldSystemFontOfSize (16);
			author.BackgroundColor = UIColor.Clear;
			author.Text = "Декстер Морган";
			author.SizeToFit();
			AddSubview (author);

			var via = new UILabel (new RectangleF(100, 80, 280, 300));
			via.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
			via.Font = UIFont.BoldSystemFontOfSize (12);
			via.BackgroundColor = UIColor.Clear;
			via.Text = "via Web";
			via.SizeToFit();
			AddSubview (via);

			var text = new UILabel (new RectangleF(20, 110, 280, 300));
			text.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
			text.Font = UIFont.SystemFontOfSize (12);
			text.Lines = 0;
			text.BackgroundColor = UIColor.Clear;
			text.Text = "текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст текст ";
			text.SizeToFit();
			AddSubview (text);

			var line = new UIImageView (UIImage.FromFile ("Tweet/line.png"));
			line.Frame = new RectangleF (20, text.Frame.Bottom + 10, 154, 1);
			AddSubview (line);

			var date = new UILabel (new RectangleF(20, line.Frame.Bottom + 5, 280, 300));
			date.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			date.Font = UIFont.BoldSystemFontOfSize (10);
			date.BackgroundColor = UIColor.Clear;
			date.Text = "13.11.2012";
			date.SizeToFit();
			AddSubview (date);

			var link = new UILabel (new RectangleF(date.Frame.Right + 25, date.Frame.Top, 280, 300));
			link.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			link.Font = UIFont.BoldSystemFontOfSize (10);
			link.BackgroundColor = UIColor.Clear;
			link.Text = "http://bit.ly/dfgasfasdd";
			link.SizeToFit();
			AddSubview (link);
		}
	}
}

