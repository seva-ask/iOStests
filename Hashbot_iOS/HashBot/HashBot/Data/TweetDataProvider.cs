using System;
using System.Collections.Generic;
using RestSharp;

namespace HashBot.Data
{
	public class TweetDataProvider
	{
		private RestClient _client = new RestClient ();

		public void GetTweets(string hashTag, Action<IEnumerable<TweetEntry>> callback)
		{
			var request = new RestRequest ("http://search.twitter.com/search.json?q=" + hashTag);
			_client.ExecuteAsync<TweetSearchResult>(request, response =>
			{
				callback(response.Data.Results);
			});
		}
	}
}

