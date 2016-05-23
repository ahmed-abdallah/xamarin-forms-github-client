using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GitHubClient
{
	public partial class RepoDetailPage : ContentPage
	{
		public RepoDetailPage(GitHubRepo repo)
		{
			InitializeComponent();

			name.Text = repo.Name;
			description.Text = repo.Description;
		}
	}
}

