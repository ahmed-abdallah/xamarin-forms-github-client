using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GitHubClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void OnViewProfileClicked(object sender, EventArgs args)
		{
			spinner.IsRunning = true;
			button.IsVisible = false;
			username.IsVisible = false;

			var service = new GitHubService();
			var url = GitHubService.BaseUrl + "users/" + username.Text;
			var user = await service.GetUser(url);

			spinner.IsRunning = false;
			button.IsVisible = true;
			username.IsVisible = true;

			if (user == null)
			{
				await DisplayAlert("Whoops!", "The user " + username.Text + " does not exist. :(", "OK");
			}
			else
			{
				//go to profile page!
				await Navigation.PushAsync(new ProfilePage(user));
			}
		}
	}
}

