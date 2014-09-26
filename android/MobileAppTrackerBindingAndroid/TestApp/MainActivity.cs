using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MobileAppTracking;
using Android.Util;
using System.Collections.Generic;

namespace TestApp
{
	[Activity (Label = "TestApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
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

				MobileAppTracker.Init(this.ApplicationContext, MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Toggle Debug Mode";
			aButton.Click += (sender, e) => {
				isDebug = !isDebug;

				Log.Info (TAG, "SetDebugMode = " + isDebug);

				MobileAppTracker.Instance.SetDebugMode(isDebug);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Toggle Allow Duplicates";
			aButton.Click += (sender, e) => {
				isAllowDup = !isAllowDup;

				Log.Info (TAG, "SetAllowDuplicates = " + isAllowDup);

				MobileAppTracker.Instance.SetAllowDuplicates(isAllowDup);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Session";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "MeasureSession");

				MobileAppTracker.Instance.MeasureSession();
			};
			layout.AddView (aButton);


			aButton = new Button (this);
			aButton.Text = "Test Event";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Measure Event");

				MobileAppTracker.Instance.MeasureAction("event1");
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Event With Items";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Measure Event With Items");

				MATEventItem item1 = new MATEventItem("apple", 1, 0.99, 0.99);
				MATEventItem item2 = new MATEventItem("banana", "attr1", "attr2", "attr3", "attr4", "attr5");

				List<MATEventItem> list = new List<MATEventItem>();
				list.Add(item1);
				list.Add(item2);

				MobileAppTracker.Instance.MeasureAction("checkout", list, 0, null, null);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Setters";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Test Setters");

				MobileAppTracker.Instance.PackageName = "com.abc.xyz";
				MobileAppTracker.Instance.SiteId = "12345";
				MobileAppTracker.Instance.UserId = "user123";
				MobileAppTracker.Instance.TRUSTeId = "truste123";
				MobileAppTracker.Instance.Latitude = 1.23;
				MobileAppTracker.Instance.Longitude = 12.3;
				MobileAppTracker.Instance.Altitude = 123.4;
				MobileAppTracker.Instance.Gender = MobileAppTracker.GenderFemale;
				MobileAppTracker.Instance.CurrencyCode = "RUB";
				MobileAppTracker.Instance.Age = 23;
				MobileAppTracker.Instance.ExistingUser = false;
				MobileAppTracker.Instance.IsPayingUser = true;
				MobileAppTracker.Instance.UserEmail = "temp@temp.com";
				MobileAppTracker.Instance.UserName = "tempUserName";
				MobileAppTracker.Instance.SetGoogleAdvertisingId("12345678-1234-1234-1234-123456789012", false);

				MobileAppTracker.Instance.FacebookUserId = "tempFacebookId";
				MobileAppTracker.Instance.GoogleUserId = "tempGoogleId";
				MobileAppTracker.Instance.TwitterUserId = "tempTwitterId";

				String matData = "\nPackageName = " + MobileAppTracker.Instance.PackageName
					+ "\nSiteId = " + MobileAppTracker.Instance.SiteId
					+ "\nUserId = " + MobileAppTracker.Instance.UserId
					+ "\nTRUSTeId = " + MobileAppTracker.Instance.TRUSTeId
					+ "\nRefId = " + MobileAppTracker.Instance.RefId
					+ "\nLatitude = " + MobileAppTracker.Instance.Latitude
					+ "\nLongitude = " + MobileAppTracker.Instance.Longitude
					+ "\nAltitude = " + MobileAppTracker.Instance.Altitude
					+ "\nAdvertiserId = " + MobileAppTracker.Instance.AdvertiserId
					+ "\nGender = " + MobileAppTracker.Instance.Gender
					+ "\nCurrencyCode = " + MobileAppTracker.Instance.CurrencyCode
					+ "\nAge = " + MobileAppTracker.Instance.Age;

				Log.Info (TAG, "MAT Data: " + matData);
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Getters";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Test Getters");

				String matId = MobileAppTracker.Instance.MatId;
				String openLogId = MobileAppTracker.Instance.OpenLogId;
				bool isPaying = MobileAppTracker.Instance.IsPayingUser;

				String matData = "\nMatId = " + matId
					+ "\nOpenLogId = " + openLogId
					+ "\nIsPayingUser = " + isPaying;

				Log.Info (TAG, matData);
			};
			layout.AddView (aButton);

			SetContentView (layout);
		}
	}
}