using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using AdSupport;
using TuneSDK;

namespace TestApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        private const string TUNE_ADVERTISER_ID = "877";
        private const string TUNE_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
        private const string TUNE_PACKAGE_NAME = "com.hasoffers.xamarinsample";

        // class-level declarations
        UIWindow window;
        TuneTestViewController viewController;
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            
            viewController = new TuneTestViewController ();
            window.RootViewController = viewController;
            window.MakeKeyAndVisible ();

            Tune.InitTracker(TUNE_ADVERTISER_ID, TUNE_CONVERSION_KEY);
            Tune.AutomateIapEventMeasurement(true);
            Tune.SetFacebookEventLogging(true, false);

            Console.WriteLine("TUNE SDK Started : adv id = {0}, conv key = {1}", TUNE_ADVERTISER_ID, TUNE_CONVERSION_KEY);

            if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                    new NSSet ());

                UIApplication.SharedApplication.RegisterUserNotificationSettings (pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications ();
            } else {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
            }
                
            return true;
        }

        public override bool ContinueUserActivity (UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            // Report Activity
            Console.WriteLine ("Continuing User Activity: {0}", userActivity.ToString ());

            Tune.HandleContinueUserActivity (userActivity, completionHandler);

            return true;
        }

        public override bool HandleOpenURL (UIApplication application, NSUrl url)
        {
            // Report Activity
            Console.WriteLine ("Handle Open Url: {0}", url.AbsoluteString);

            Tune.HandleOpenURL (url.AbsoluteString, application);

            return true;
        }
    }
}

