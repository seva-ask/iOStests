using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Screens.TweetList;

namespace HashBot.Screens
{
	public partial class TweetNavigationController : UINavigationController
	{
		private string _hashTag;

		public TweetNavigationController (string hashtag) : base ("TweetNavigationController", null)
		{
			_hashTag = hashtag;
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

			PushViewController (new TweetListController (_hashTag), false);
		}
	}
}

