using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GitHubClient
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new MainPage()); // using content page
			//MainPage = new NavigationPage(new TabbedMainPage()); // using tabbed page 
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

