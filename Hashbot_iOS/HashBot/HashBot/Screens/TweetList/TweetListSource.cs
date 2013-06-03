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
			return 2;
		}

		public override UIView GetViewForFooter (UITableView tableView, int section)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/ios/tutorials/Events%2c_Protocols_and_Delegates

			var container = new UIView ();

			var button = new UIButton (UIButtonType.Custom);
			button.SetTitle ("Показать еще", UIControlState.Normal);
			button.Frame = new RectangleF(10, 15, 300, 55);
			button.Font = UIFont.BoldSystemFontOfSize (17);
			button.SetTitleColor(UIColor.FromRGB (0x00, 0x00, 0x00), UIControlState.Normal);
			button.SetBackgroundImage(UIImage.FromFile("Backgrounds/button.png").CreateResizableImage(new UIEdgeInsets(0, 10, 0, 10)), UIControlState.Normal);
			button.SetBackgroundImage(UIImage.FromFile("Backgrounds/button_pressed.png").CreateResizableImage(new UIEdgeInsets(0, 10, 0, 10)), UIControlState.Highlighted);
			container.AddSubview (button);

			return container;
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
			
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			_parentController.NavigationController.PushViewController (new TweetDetailsController(), true);
			tableView.DeselectRow (indexPath, true);
		}
	}
}

