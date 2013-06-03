using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace HashBot.Screens.Info
{
	public class InfoView : UIView
	{
		private void AddButton (string imageName, float leftBound)
		{
			var button = new UIButton (UIButtonType.Custom);
			button.Frame = new RectangleF (leftBound, 320, 95, 54);
			button.ImageEdgeInsets = new UIEdgeInsets (-12, 0, 0, 0);
			button.SetImage (UIImage.FromFile ("Info/icon_" + imageName + ".png"), UIControlState.Normal);
			button.SetBackgroundImage (UIImage.FromFile ("Info/button.png").CreateResizableImage (new UIEdgeInsets (0, 10, 0, 10)), UIControlState.Normal);
			button.SetBackgroundImage (UIImage.FromFile ("Info/button_pressed.png").CreateResizableImage (new UIEdgeInsets (0, 10, 0, 10)), UIControlState.Highlighted);
			AddSubview (button);
		}

		public InfoView ()
		{
			BackgroundColor = UIColor.White;

			var image = new UIImageView (UIImage.FromFile ("Info/logo.png"));
			image.Frame = new RectangleF (70, 0, 179, 138);
			AddSubview (image);

			var text = new UILabel (new RectangleF(20, 138, 280, 300));
			text.TextColor = UIColor.FromRGB (0x41, 0x41, 0x41);
			text.Font = UIFont.SystemFontOfSize (13);
			text.Lines = 0;
			text.Text = "Нам не стыдно за выпускаемые продукты, все они сделаны с вниманием к деталям. Пользователи это ценят, многие наши приложения попадают в топы AppStore и получают высокие оценки.\n\nМы любим своих заказчиков и решаем их задачи. На письма и телефон отвечаем быстро, по праздникам и выходным, делаем работу в срок и никуда не пропадаем.\nЗакажите разработку сейчас!";
			text.SizeToFit();
			AddSubview (text);

			AddButton ("phone", 20);
			AddButton ("mail", 205);
		}
	}
}

