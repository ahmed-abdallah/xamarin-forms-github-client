using System;
using Xamarin.Forms;
using System.Threading.Tasks;

#if __ANDROID__
using Android.Support.Design.Widget;
using Android.Content;
#elif __IOS__

#endif

namespace GitHubClient
{
	public class AlertHelper
	{
		// This is our basic alert
		async static public Task ShowAlert(Page page, string title, string message, string cancel)
		{
			await page.DisplayAlert(title, message, cancel);
		}

	}
}

