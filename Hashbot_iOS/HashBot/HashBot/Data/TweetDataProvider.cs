using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace HashBot.Data
{
	public class TweetDataProvider
	{
		private RestClient _client;

		public TweetDataProvider ()
		{
			_client = new RestClient ();
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource ("MWKIDCTFFkowvIumacFEg", "oN8IJ739JA3KzPO8Q5E51GSrbMfJezVNoNQ7f4WkwOg",
			                                                                  "1527662420-F5jOhT11DpZvozf3IshMaAetd1FFN41KZyf84Io", "GvU6UMh4h4ATDFQVbUkTjXafHBC8nrjKBJdrjmE7aw");
		}

		public void GetTweets(string hashTag, Action<IEnumerable<TweetEntry>> callback)
		{
			var request = new RestRequest ("https://api.twitter.com/1.1/search/tweets.json");
			request.AddParameter ("q", hashTag);
			_client.ExecuteAsync<TweetSearchResult>(request, response =>
			{
				callback(response.Data.Statuses);
			});
		}
	}
}

