using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Data;

namespace HashBot.Screens.Details
{
	public partial class TweetDetailsController : UIViewController
	{
		public TweetDetailsController (TweetEntry tweet)
		{
			Title = "Твит";
			View = new DetailsView (tweet);
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
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			TabBarController.TabBar.Hidden = true;
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			TabBarController.TabBar.Hidden = false;
		}
	}
}

