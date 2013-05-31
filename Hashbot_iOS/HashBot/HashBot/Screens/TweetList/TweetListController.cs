using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot.Screens.TweetList
{
	public class TweetListController : UITableViewController
	{
		private string _hashTag;

		public TweetListController (string hashtag) : base (UITableViewStyle.Grouped)
		{
			_hashTag = hashtag;
			NavigationItem.RightBarButtonItem = new UIBarButtonItem ("Инфо", UIBarButtonItemStyle.Plain,
				(e,args) =>
				{
					NavigationController.PushViewController (new InfoController(), true);
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

