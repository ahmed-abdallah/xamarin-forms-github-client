using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GitHubClient
{
	public partial class ReposPage : ContentPage
	{
		public ReposPage(List<GitHubRepo> repos)
		{
			InitializeComponent();
			RepoList.ItemsSource = repos;
		}

		async void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			//repo
			var repo = e.SelectedItem as GitHubRepo;
			await Navigation.PushAsync(new RepoDetailPage(repo));

			//disable the visual selection state.
			((ListView)sender).SelectedItem = null;
		}
	}
}

