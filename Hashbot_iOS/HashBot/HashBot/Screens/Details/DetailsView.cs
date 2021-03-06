using System;
using MonoTouch.UIKit;
using System.Drawing;
using HashBot.Data;
using System.Globalization;
using RestSharp.Contrib;
using System.Text.RegularExpressions;

namespace HashBot.Screens.Details
{
	public class DetailsView : UIView
	{
		private ImageLoader _imageLoader;

		public DetailsView (TweetEntry tweet)
		{
			_imageLoader = new ImageLoader ();

			var bg = new UIImageView(UIImage.FromFile ("Tweet/bg.png"));
			AddSubview (bg);

			var imageView = new UIImageView ();
			imageView.Frame = new RectangleF (20, 30, 64, 64);

			_imageLoader.GetImage (tweet.User.ProfileImageUrl, (url, image) => InvokeOnMainThread(() =>
			{
				if (tweet.User.ProfileImageUrl == url)
				{
					imageView.Image = image;	
				}
			}));

			AddSubview (imageView);

			var author = new UILabel (new RectangleF(100, 50, 280, 300));
			author.TextColor = UIColor.FromRGB (0x44, 0x64, 0x8f);
			author.Font = UIFont.BoldSystemFontOfSize (16);
			author.BackgroundColor = UIColor.Clear;
			author.Text = tweet.User.Name;
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
			text.Text = HttpUtility.HtmlDecode (tweet.Text);
			text.SizeToFit();
			AddSubview (text);

			var line = new UIImageView (UIImage.FromFile ("Tweet/line.png"));
			line.Frame = new RectangleF (20, text.Frame.Bottom + 10, 154, 1);
			AddSubview (line);

			var date = new UILabel (new RectangleF(20, line.Frame.Bottom + 5, 280, 300));
			date.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			date.Font = UIFont.BoldSystemFontOfSize (10);
			date.BackgroundColor = UIColor.Clear;
			date.Text = tweet.CreatedAt.ToString ("d", CultureInfo.CreateSpecificCulture ("de-DE"));
			date.SizeToFit();
			AddSubview (date);

			var link = new UILabel (new RectangleF(date.Frame.Right + 25, date.Frame.Top, 280, 300));
			link.TextColor = UIColor.FromRGB (0x77, 0x77, 0x77);
			link.Font = UIFont.BoldSystemFontOfSize (10);
			link.BackgroundColor = UIColor.Clear;
			link.Text = GetLinkFromTag(HttpUtility.HtmlDecode (tweet.Source));
			link.SizeToFit();
			AddSubview (link);
		}

		private string GetLinkFromTag(string tag)
		{
			var regexp = new Regex ("<a href=\"(.*)\">.*");
			return regexp.Match(tag).Groups[1].Value;
		}
	}
}

