using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubClient
{
	public class GitHubService
	{
		HttpClient client;
		const string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.94 Safari/537.36";
		internal const string BaseUrl = "https://api.github.com/";

	  	public GitHubService()
		{
			client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
			client.MaxResponseContentBufferSize = 256000;
	  	}

		public async Task<List<GitHubUser>> GetUsers(string url)
		{
			var uri = new Uri(string.Format(url, string.Empty));
  			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var users = JsonConvert.DeserializeObject<List<GitHubUser>>(content);
				return users;
			}
			else
			{
				//error
				return null;
			}
		}

		public async Task<GitHubUser> GetUser(string url)
		{
			var uri = new Uri(string.Format(url, string.Empty));
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var user = JsonConvert.DeserializeObject<GitHubUser>(content);
				return user;
			}
			else
			{
				//error
				return null;
			}
		}


		public async Task<List<GitHubRepo>> GetRepos(string url)
		{
			var uri = new Uri(string.Format(url, string.Empty));
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var items = JsonConvert.DeserializeObject<List<GitHubRepo>>(content);
				return items;
			}
			else
			{
				//error
				return null;
			}
		}

		public async Task<GitHubRepo> GetRepo(string url)
		{
			var uri = new Uri(string.Format(url, string.Empty));
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var item = JsonConvert.DeserializeObject<GitHubRepo>(content);
				return item;
			}
			else
			{
				//error
				return null;
			}
		}
	}
}

