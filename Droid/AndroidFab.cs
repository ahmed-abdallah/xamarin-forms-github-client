using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Animation;
using Android.Views.Animations;
using DrawableCompat = Android.Support.V4.Graphics.Drawable.DrawableCompat;

namespace GitHubClient.Droid
{
	public class AndroidFab : FloatingActionButton
	{

		public AndroidFab(Context context) :
			base(context)
		{

		}

		public AndroidFab(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
		}

		public AndroidFab(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
		}

		public AndroidFab(IntPtr handle, JniHandleOwnership own)
			: base(handle, own)
		{
		}


	}
}