using System;

namespace HashBot.Data
{
	public class TweetEntry
	{
		public string Text { get; set; }

		public DateTime CreatedAt { get; set; }

		public TweetUser User { get; set; }

		public string Source { get; set; }
	}
}

