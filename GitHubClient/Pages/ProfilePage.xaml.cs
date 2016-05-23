using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GitHubClient
{
	public partial class ProfilePage : ContentPage
	{
		GitHubUser User { get; set; }
		GitHubService Service { get; set;}

		public ProfilePage(GitHubUser user)
		{
			InitializeComponent();
			User = user;
			Service = new GitHubService();

			if (user != null)
			{
				avatar.Source = user.Avatar_Url;
				username.Text = user.Login;
			}
		}

		async void OnViewReposClicked(object sender, EventArgs args)
		{
			var url = User.Repos_Url;
			var repos = await Service.GetRepos(url);

			if (repos == null || repos.Count <= 0)
			{
				await DisplayAlert("Whoops!", "This user doesn't have any repos. :(", "OK");
			}
			else
			{
				//go to repos page!
				await Navigation.PushAsync(new ReposPage(repos));
			}
		}

		async void OnViewFollowersClicked(object sender, EventArgs args)
		{
			var url = User.Followers_Url;
			var users = await Service.GetUsers(url);

			if (users == null || users.Count <= 0)
			{
				await DisplayAlert("Whoops!", "This user doesn't follow anyone. :(", "OK");
			}
			else
			{
				//go to followers page!
				await Navigation.PushAsync(new UsersPage(users, "Followers"));
			}
		}

		async void OnViewFollowingClicked(object sender, EventArgs args)
		{
			var url = User.Following_Url.Split('{')[0];
			var users = await Service.GetUsers(url);

			if (users == null || users.Count <=0)
			{
				await DisplayAlert("Whoops!", "This user isn't following anyone. :(", "OK");
			}
			else
			{
				//go to following page!
				await Navigation.PushAsync(new UsersPage(users, "Following"));
			}
		}
	}
}

