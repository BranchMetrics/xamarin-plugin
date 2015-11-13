using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Collections.Generic;
using MobileAppTracking;

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

		MobileAppTracker mat;

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

				mat = MobileAppTracker.Init(this.ApplicationContext, MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
				mat.SetFacebookEventLogging(true, this, false);
				MATDeeplinkListener listener = new MATDeeplinkListener();
				mat.CheckForDeferredDeeplink(listener);
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
			aButton.Text = "Test Session";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "MeasureSession");

				mat.SetReferralSources(this);
				mat.MeasureSession();
			};
			layout.AddView (aButton);


			aButton = new Button (this);
			aButton.Text = "Test Event";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Measure Event");

				mat.MeasureEvent("event1");
			};
			layout.AddView (aButton);

			aButton = new Button (this);
			aButton.Text = "Test Event With Items";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Measure Event With Items");

				MATEventItem item1 = new MATEventItem("apple")
					.WithQuantity(1)
					.WithRevenue(0.99)
					.WithUnitPrice(0.99);
				MATEventItem item2 = new MATEventItem("banana")
					.WithAttribute1("attr1")
					.WithAttribute2("attr2")
					.WithAttribute3("attr3")
					.WithAttribute4("attr4")
					.WithAttribute5("attr5");

				List<MATEventItem> list = new List<MATEventItem>();
				list.Add(item1);
				list.Add(item2);

				MATEvent matEvent = new MATEvent("checkout").WithEventItems(list);

				mat.MeasureEvent(matEvent);
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
				mat.Latitude = 1.23;
				mat.Longitude = 12.3;
				mat.Altitude = 123.4;
				mat.Gender = MATGender.Female;
				mat.CurrencyCode = "RUB";
				mat.Age = 23;
				mat.ExistingUser = false;
				mat.IsPayingUser = true;
				mat.UserEmail = "temp@temp.com";
				mat.UserName = "tempUserName";
				mat.SetGoogleAdvertisingId("12345678-1234-1234-1234-123456789012", false);

				mat.FacebookUserId = "tempFacebookId";
				mat.GoogleUserId = "tempGoogleId";
				mat.TwitterUserId = "tempTwitterId";

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

			aButton = new Button (this);
			aButton.Text = "Test Getters";
			aButton.Click += (sender, e) => {
				Log.Info (TAG, "Test Getters");

				String matId = mat.MatId;
				String openLogId = mat.OpenLogId;
				bool isPaying = mat.IsPayingUser;

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