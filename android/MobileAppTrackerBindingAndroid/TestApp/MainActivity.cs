using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HasOffers;
using Android.Util;
using System.Collections.Generic;

namespace TestApp
{
	[Activity (Label = "TestApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		MobileAppTracker mat;

		const String MAT_ADVERTISER_ID = "877";
		const String MAT_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";

		bool isDebug = false;
		bool isAllowDup = false;

		const string TAG = "testMATXamarin";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Create the user interface in code
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			// Get our button from the layout resource,
			// and attach an event to it
			var aButton = new Button (this);
			aButton.Text = "Start MobileAppTracker";
			aButton.Click += delegate {
				Log.Info (TAG, "MobileAppTracker constructor");

				mat = new MobileAppTracker (this, MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Toggle Debug Mode";
			aButton.Click += (sender, e) => {
				isDebug = !isDebug;

				Log.Info (TAG, "SetDebugMode = " + isDebug);

				mat.SetDebugMode(isDebug);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Toggle Allow Duplicates";
			aButton.Click += (sender, e) => {
				isAllowDup = !isAllowDup;

				Log.Info (TAG, "SetAllowDuplicates = " + isAllowDup);

				mat.SetAllowDuplicates(isAllowDup);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Install";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "TrackInstall");

				mat.TrackInstall();
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Update";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "TrackUpdate");

				mat.TrackUpdate();
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Event";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Track Event");

				mat.TrackAction("event1");
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Event With Items";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Track Event With Items");

				MATEventItem item1 = new MATEventItem("apple", 1, 0.99, 0.99);
				MATEventItem item2 = new MATEventItem("banana", "att1", "att2", "att3", "att4", "att5");

				List<MATEventItem> list = new List<MATEventItem>();
				list.Add(item1);
				list.Add(item2);

				mat.TrackAction("checkout", list);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Setters";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Test Setters");

				mat.PackageName = "com.abc.xyz";
				mat.SiteId = "12345";
				mat.UserId = "user123";
				mat.TRUSTeId = "truste123";
				mat.RefId = "ref123";
				mat.Latitude = 1.23;
				mat.Longitude = 12.3;
				mat.Altitude = 123.4;
				mat.AdvertiserId = "5432";
				mat.Gender = MobileAppTracker.GenderFemale;
				mat.CurrencyCode = "RUB";
				mat.Age = 23;

				mat.SetFacebookUserId("tempFacebookId");
				mat.SetGoogleUserId("tempGoogleId");
				mat.SetTwitterUserId("tempTwitterId");

				String matData = "\nPackageName = " + mat.PackageName
								+ "\nSiteId = " + mat.SiteId
								+ "\nUserId = " + mat.UserId
								+ "\nTRUSTeId = " + mat.TRUSTeId
								+ "\nRefId = " + mat.RefId
								+ "\nLatitude = " + mat.Latitude
								+ "\nLongitude = " + mat.Longitude
								+ "\nAltitude = " + mat.Altitude
								+ "\nAdvertiserId = " + mat.AdvertiserId
								+ "\nGender = " + mat.Gender
								+ "\nCurrencyCode = " + mat.CurrencyCode
								+ "\nAge = " + mat.Age;

				Log.Info (TAG, "MAT Data: " + matData);
			};
			layout.AddView (aButton);

			SetContentView (layout);
		}
	}
}


