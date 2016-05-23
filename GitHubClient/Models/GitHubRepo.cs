using System;
namespace GitHubClient
{
	public class GitHubRepo
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Full_Name { get; set; }
		public bool Private { get; set; }
		public string Description { get; set; }
		public bool Fork { get; set; }
		public string Url { get; set; }
		public DateTime Created_At { get; set; }
		public DateTime Updated_At { get; set; }
		public DateTime Pushed_At { get; set; }
		public long Size { get; set; }
		public string Language { get; set; }
		public int Watchers { get; set; }
	}
}

