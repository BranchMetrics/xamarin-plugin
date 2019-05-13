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
using Com.Tune.Application;

namespace TestApp {
    [Activity(Label = "TestApp", MainLauncher = true)]
    public class MainActivity : TuneActivity {
        bool isDebug = false;

        const string TAG = "testTuneXamarin";

        ITune tune;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            tune = Tune.Instance;

            //Create the user interface in code
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            // Get our button from the layout resource,
            // and attach an event to it
            Button aButton = new Button(this);
            aButton.Text = "Toggle Debug Mode";
            aButton.Click += (sender, e) => {
                isDebug = !isDebug;

                Log.Info(TAG, "SetDebugMode = " + isDebug);

                if (isDebug) TuneDebugLog.EnableLog();
                else TuneDebugLog.DisableLog();
            };
            layout.AddView(aButton);

            aButton = new Button(this);
            aButton.Text = "Test Session";
            aButton.Click += (sender, e) => {
                Log.Info(TAG, "MeasureSession");

                (tune as TuneInternal).MeasureSessionInternal();
            };
            layout.AddView(aButton);


            aButton = new Button(this);
            aButton.Text = "Test Event";
            aButton.Click += (sender, e) => {
                Log.Info(TAG, "Measure Event");

                tune.MeasureEvent("event1");
            };
            layout.AddView(aButton);

            aButton = new Button(this);
            aButton.Text = "Test Event With Items";
            aButton.Click += (sender, e) => {
                Log.Info(TAG, "Measure Event With Items");

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
            layout.AddView(aButton);

            aButton = new Button(this);
            aButton.Text = "Test Setters";
            aButton.Click += (sender, e) => {
                Log.Info(TAG, "Test Setters");

                tune.UserId = "user123";
                tune.Age = 23;
                tune.ExistingUser = false;
                tune.UserEmail = "temp@temp.com";
                tune.UserName = "tempUserName";

                tune.FacebookUserId = "tempFacebookId";
                tune.GoogleUserId = "tempGoogleId";
                tune.TwitterUserId = "tempTwitterId";

                String tuneData = "\nPackageName = " + tune.PackageName
                    + "\nUserId = " + tune.UserId
                    + "\nAdvertiserId = " + tune.AdvertiserId
                    + "\nGender = " + tune.Gender
                    + "\nAge = " + tune.Age;

                Log.Info(TAG, "TUNE Data: " + tuneData);
            };
            layout.AddView(aButton);

            aButton = new Button(this);
            aButton.Text = "Test Getters";
            aButton.Click += (sender, e) => {
                Log.Info(TAG, "Test Getters");

                String tuneId = tune.MatId;
                String openLogId = tune.OpenLogId;

                String tuneData = "\nmatId = " + tuneId
                    + "\nOpenLogId = " + openLogId;

                Log.Info(TAG, tuneData);
            };
            layout.AddView(aButton);

            SetContentView(layout);
        }
    }
}