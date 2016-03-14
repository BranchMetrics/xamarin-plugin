using Android.App;
using Android.Runtime;
using System;
using System.Collections.Generic;
using TuneSDK;
using Com.Tune.MA.Application;
using Com.Tune.MA.Configuration;
using Com.Tune.MA.Experiments.Model;
using Com.Tune.MA.Model;

namespace TestApp
{
    [Application]
    public class MainApplication : TuneApplication
    {
        const String TUNE_ADVERTISER_ID = "877";
        const String TUNE_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
        const bool turnOnTMA = true;
        TuneConfiguration tuneConfig;

        Tune tune;

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            //app init ...

            tuneConfig = new TuneConfiguration ();
            tuneConfig.SetDebugLoggingOn (true);
            tuneConfig.SetEchoAnalytics (true);
            tuneConfig.SetEchoConfigurations (true);
            tuneConfig.SetEchoPlaylists (true);
            tuneConfig.SetEchoPushes (true);

            tune = Tune.Init(this.ApplicationContext, TUNE_ADVERTISER_ID, TUNE_CONVERSION_KEY, turnOnTMA, tuneConfig);
            tune.SetFacebookEventLogging(true, this, false);
            tune.CheckForDeferredDeeplink(new TuneDeeplinkListener());

            tune.RegisterPowerHook ("hookId", "friendlyName", "defaultValue");

            Dictionary<string, string> defaultData = new Dictionary<string, string> ();
            defaultData.Add ("title", "Alert");
            defaultData.Add ("message", "Alert message to be shown");

            tune.RegisterDeepAction("myDialogAction", "Show Dialog", defaultData, new TuneDialogDeepAction());

            Dictionary<string, TuneInAppMessageExperimentDetails> experimentDetails = new Dictionary<string, TuneInAppMessageExperimentDetails>(tune.InAppMessageExperimentDetails);

            tune.SetPushNotificationSenderId ("963580496599");
        }
    }

    public class TuneDialogDeepAction : Java.Lang.Object, ITuneDeepActionCallback {
        public void Execute(Activity activity, IDictionary<string, string> extraData) {
            AlertDialog alertDialog = new AlertDialog.Builder (activity).Create ();
            string title, message;
            extraData.TryGetValue ("title", out title);
            extraData.TryGetValue ("message", out message);
            alertDialog.SetTitle (title);
            alertDialog.SetMessage (message);
            alertDialog.Show ();
        }
    }
}

