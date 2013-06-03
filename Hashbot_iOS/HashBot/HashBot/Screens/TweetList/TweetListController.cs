using System;
using System.Linq;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Screens.Info;
using HashBot.Data;

namespace HashBot.Screens.TweetList
{
	public class TweetListController : UITableViewController
	{
		private string _hashTag;

		private TweetDataProvider _provider;

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
			_provider.GetTweets (_hashTag, tweets => 
			{
				InvokeOnMainThread( () =>
				{
					(TableView.Source as TweetListSource).AddTweets (tweets);
					TableView.ReloadData();
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
			TableView.Source = new TweetListSource (this);
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

