using System;
using System.Linq;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Screens.Info;
using HashBot.Data;
using System.Collections.Generic;

namespace HashBot.Screens.TweetList
{
	public class TweetListController : UITableViewController
	{
		private string _hashTag;

		private TweetDataProvider _provider;

		private UIActivityIndicatorView _progressBar;

		public TweetListController (string hashtag) : base (UITableViewStyle.Plain)
		{
			_hashTag = hashtag;
			NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Инфо", UIBarButtonItemStyle.Plain,
				(e,args) =>
				{
					NavigationController.PushViewController (new InfoController(), true);
				});
			var background = new UIView (new RectangleF(0,0,320,480));
			background.BackgroundColor = UIColor.White;
			TableView.BackgroundView = background;

			_provider = new TweetDataProvider ();

			_progressBar = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			_progressBar.Color = UIColor.Red;
			_progressBar.Frame = new RectangleF (0, -200, 40, 40);
			_progressBar.Center = this.View.Center;
			this.View.AddSubview (_progressBar);
			this.View.BringSubviewToFront(_progressBar);

			LoadNewTweets ();
		}

		private void LoadNewTweets ()
		{
			_progressBar.StartAnimating ();
			_provider.GetTweets (_hashTag, tweets =>
			{
				InvokeOnMainThread (() =>
				{
					(TableView.Source as TweetListSource).AddTweets (tweets);
					TableView.ReloadData ();
					_progressBar.StopAnimating ();
				});
			});
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Register the TableView's data source
			TableView.Source = new TweetListSource (this, GetFooter());
		}

		private UIView GetFooter()
		{
			var container = new UIView ();

			var button = new UIButton (UIButtonType.RoundedRect);
			button.SetTitle ("Показать еще", UIControlState.Normal);
			button.Frame = new RectangleF(10, 15, 300, 55);
			button.Font = UIFont.BoldSystemFontOfSize (17);
			button.SetTitleColor(UIColor.FromRGB (0x00, 0x00, 0x00), UIControlState.Normal);
			button.TouchUpInside += (sender, e) => LoadNewTweets();
			container.AddSubview (button);

			return container;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			Title = "#" + _hashTag;
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			Title = "Твиты";
		}
	}
}

