
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

#if __ANDROID__
using GitHubClient.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Views;
#endif



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

			var pageLayout = (StackLayout)Content;

			var absolute = new AbsoluteLayout()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			// Position the pageLayout to fill the entire screen.
			// Manage positioning of child elements on the page by editing the pageLayout.
			AbsoluteLayout.SetLayoutFlags(pageLayout, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(pageLayout, new Rectangle(0f, 0f, 1f, 1f));
			absolute.Children.Add(pageLayout);


			var stack = new StackLayout
			{
				Padding = 8,
				HorizontalOptions = LayoutOptions.Center,
			};

			#if __ANDROID__
			//let's make a FAB and add it for Android only
			var fab = new CheckableFab(Forms.Context);
			fab.SetImageResource(Android.Resource.Drawable.IcMenuSearch);

			fab.Click += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};


			fab.UseCompatPadding = true;

			stack.Children.Add(fab);

			absolute.Children.Add(stack);
			// Overlay the FAB in the bottom-right corner
			AbsoluteLayout.SetLayoutFlags(stack, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(stack, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			// set our page content to the new layout with FAB
			this.Content = absolute;
			#endif
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

