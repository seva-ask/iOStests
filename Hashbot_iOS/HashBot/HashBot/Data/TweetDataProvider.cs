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
			var request = new RestRequest ("https://api.twitter.com/1.1/search/tweets.json?q=" + hashTag);
			_client.Authenticator.Authenticate (_client, request);
	//		request.AddHeader ("Authorization", "OAuth oauth_consumer_key=\"MWKIDCTFFkowvIumacFEg\", oauth_nonce=\"724608944c79de80b984c58a76904afa\", oauth_signature=\"XlDuuNwnz%2FOGOp9tyJt%2FR2twIiE%3D\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"" + DateTime.Now.Ticks + "\", oauth_token=\"1527662420-F5jOhT11DpZvozf3IshMaAetd1FFN41KZyf84Io\", oauth_version=\"1.0\"");
			_client.ExecuteAsync<TweetSearchResult>(request, response =>
			{
				callback(response.Data.Statuses);
			});
		}
	}
}

