using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HashBot.Screens.TweetList
{
	public class TweetListSource : UITableViewSource
	{
		private UIViewController _parentController;

		public TweetListSource (UIViewController parentController)
		{
			_parentController = parentController;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return 1;
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Header";
		}

		public override string TitleForFooter (UITableView tableView, int section)
		{
			return "Footer";
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (TweetListCell.Key) as TweetListCell;
			if (cell == null)
				cell = new TweetListCell ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.DetailTextLabel.Text = "DetailsTextLabel";
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_parentController.NavigationController.PushViewController (new TweetDetailsController(), true);
			tableView.DeselectRow (indexPath, true);
		}
	}
}

