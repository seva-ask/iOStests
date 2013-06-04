using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HashBot.Screens.Details;
using HashBot.Data;
using System.Collections.Generic;
using System.Linq;

namespace HashBot.Screens.TweetList
{
	public class TweetListSource : UITableViewSource
	{
		private UIViewController _parentController;

		private UIView _footer;

		private IEnumerable<TweetEntry> _tweets = new List<TweetEntry>();

		public TweetListSource (UIViewController parentController, UIView footer)
		{
			_parentController = parentController;
			_footer = footer;
		}

		public void AddTweets(IEnumerable<TweetEntry> tweets)
		{
			_tweets = _tweets.Union (tweets).Distinct().OrderByDescending (tweet => tweet.CreatedAt);
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return _tweets.Count();
		}

		public override UIView GetViewForFooter (UITableView tableView, int section)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/ios/tutorials/Events%2c_Protocols_and_Delegates
			return _footer;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/ios/tutorials/Events%2c_Protocols_and_Delegates 
			return 55;
		}

		public override float GetHeightForFooter (UITableView tableView, int section)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/ios/tutorials/Events%2c_Protocols_and_Delegates 
			return 70;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (TweetListCell.Key) as TweetListCell;
			if (cell == null)
				cell = new TweetListCell ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
	//		cell.DetailTextLabel.Text = "DetailsTextLabel";
			cell.Tweet = _tweets.ElementAt (indexPath.Row);
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_parentController.NavigationController.PushViewController (new TweetDetailsController(_tweets.ElementAt (indexPath.Row)), true);
			tableView.DeselectRow (indexPath, true);
		}
	}
}

