using System;

namespace HashBot.Data
{
	public class TweetEntry
	{
		public string FromUserName { get; set; }

		public string Text { get; set; }

		public DateTime CreatedAt { get; set; }

		public string ProfileImageUrl { get; set; }

		public string Source { get; set; }
	}
}

