using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Gms.Common;
using System.Collections.Generic;
using TuneSDK;
using Com.Tune.MA.Application;

namespace TestApp
{
    [Activity (Label = "TestApp", MainLauncher = true)]
    public class MainActivity : TuneActivity
    {
        bool isDebug = false;

        const string TAG = "testTuneXamarin";

        Tune tune;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            tune = Tune.Instance;

            //Create the user interface in code
            var layout = new LinearLayout (this);
            layout.Orientation = Orientation.Vertical;

            TextView powerhookText = new TextView (this);
            powerhookText.Text = tune.GetValueForHookById ("hookId");
            layout.AddView (powerhookText);

            // Get our button from the layout resource,
            // and attach an event to it
            Button aButton = new Button (this);
            aButton.Text = "Toggle Debug Mode";
            aButton.Click += (sender, e) => {
                isDebug = !isDebug;

                Log.Info (TAG, "SetDebugMode = " + isDebug);

                tune.SetDebugMode(isDebug);
            };
            layout.AddView (aButton);

            aButton = new Button (this);
            aButton.Text = "Test Session";
            aButton.Click += (sender, e) => {
                Log.Info (TAG, "MeasureSession");

                tune.SetReferralSources(this);
                tune.MeasureSession();
            };
            layout.AddView (aButton);


            aButton = new Button (this);
            aButton.Text = "Test Event";
            aButton.Click += (sender, e) => {
                Log.Info (TAG, "Measure Event");

                tune.MeasureEvent("event1");
            };
            layout.AddView (aButton);

            aButton = new Button (this);
            aButton.Text = "Test Event With Items";
            aButton.Click += (sender, e) => {
                Log.Info (TAG, "Measure Event With Items");

                TuneEventItem item1 = new TuneEventItem("apple")
                    .WithQuantity(1)
                    .WithRevenue(0.99)
                    .WithUnitPrice(0.99);
                TuneEventItem item2 = new TuneEventItem("banana")
                    .WithAttribute1("attr1")
                    .WithAttribute2("attr2")
                    .WithAttribute3("attr3")
                    .WithAttribute4("attr4")
                    .WithAttribute5("attr5");

                List<TuneEventItem> list = new List<TuneEventItem>();
                list.Add(item1);
                list.Add(item2);

                TuneEvent tuneEvent = new TuneEvent("checkout").WithEventItems(list);

                tune.MeasureEvent(tuneEvent);
            };
            layout.AddView (aButton);

            aButton = new Button (this);
            aButton.Text = "Test Setters";
            aButton.Click += (sender, e) => {
                Log.Info (TAG, "Test Setters");

                tune.PackageName = "com.abc.xyz";
                tune.UserId = "user123";
                tune.TRUSTeId = "truste123";
                tune.Latitude = 1.23;
                tune.Longitude = 12.3;
                tune.Altitude = 123.4;
                tune.Gender = TuneGender.Female;
                tune.CurrencyCode = "RUB";
                tune.Age = 23;
                tune.ExistingUser = false;
                tune.IsPayingUser = true;
                tune.UserEmail = "temp@temp.com";
                tune.UserName = "tempUserName";
                tune.SetGoogleAdvertisingId("12345678-1234-1234-1234-123456789012", false);

                tune.FacebookUserId = "tempFacebookId";
                tune.GoogleUserId = "tempGoogleId";
                tune.TwitterUserId = "tempTwitterId";

                String tuneData = "\nPackageName = " + tune.PackageName
                    + "\nUserId = " + tune.UserId
                    + "\nTRUSTeId = " + tune.TRUSTeId
                    + "\nRefId = " + tune.RefId
                    + "\nLatitude = " + tune.Latitude
                    + "\nLongitude = " + tune.Longitude
                    + "\nAltitude = " + tune.Altitude
                    + "\nAdvertiserId = " + tune.AdvertiserId
                    + "\nGender = " + tune.Gender
                    + "\nCurrencyCode = " + tune.CurrencyCode
                    + "\nAge = " + tune.Age;

                Log.Info (TAG, "TUNE Data: " + tuneData);
            };
            layout.AddView (aButton);

            aButton = new Button (this);
            aButton.Text = "Test Getters";
            aButton.Click += (sender, e) => {
                Log.Info (TAG, "Test Getters");

                String tuneId = tune.MatId;
                String openLogId = tune.OpenLogId;
                bool isPaying = tune.IsPayingUser;

                String tuneData = "\nmatId = " + tuneId
                    + "\nOpenLogId = " + openLogId
                    + "\nIsPayingUser = " + isPaying;

                Log.Info (TAG, tuneData);
            };
            layout.AddView (aButton);

            SetContentView (layout);
        }
    }
}