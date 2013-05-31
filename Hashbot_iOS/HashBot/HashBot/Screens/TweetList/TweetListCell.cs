using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot.Screens.TweetList
{
	public class TweetListCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("TweetListCell");

		public TweetListCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

