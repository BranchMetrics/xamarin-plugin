using System;
using MobileAppTracking;

namespace TestApp
{
	public class MATDeeplinkListener : Java.Lang.Object, IMATDeeplinkListener 
	{
		public MATDeeplinkListener ()
		{
		}

		public void DidReceiveDeeplink(string deeplink)
		{
			Console.WriteLine ("MAT DidReceiveDeeplink: " + deeplink);
			// Pass deferred deeplink value to MAT
			MobileAppTracker.Instance.ReferralUrl = deeplink;
			// TODO: handle deeplink redirection
		}

		public void DidFailDeeplink(string error)
		{
			Console.WriteLine ("MAT DidFailDeeplink: error = " + error);
		}
	}
}

