using System;
using RestSharp;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace HashBot.Data
{
	public class ImageLoader
	{
		private RestClient _client = new RestClient ();

		public void GetImage(string url, Action<string, UIImage> callback)
		{
			var request = new RestRequest (url);
			_client.ExecuteAsync(request, response =>
			{
				using (var data = NSData.FromArray (response.RawBytes))
				{
					callback(url, UIImage.LoadFromData (data));
				}
			});
		}
	}
}

