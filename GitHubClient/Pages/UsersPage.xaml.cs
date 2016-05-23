using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GitHubClient
{
	public partial class UsersPage : ContentPage
	{
		public UsersPage(List<GitHubUser> users, string title)
		{
			InitializeComponent();

			UserList.ItemsSource = users;
			Title = title;
		}

		async void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			//user
			var user = e.SelectedItem as GitHubUser;
			await Navigation.PushAsync(new ProfilePage(user));

			//disable the visual selection state.
			((ListView)sender).SelectedItem = null;
		}
	}
}

