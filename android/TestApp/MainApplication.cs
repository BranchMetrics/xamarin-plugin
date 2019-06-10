using Android.App;
using Android.OS;
using Android.Runtime;
using System;
using System.Collections.Generic;
using TuneSDK;
using Com.Tune.Application;

namespace TestApp
{
    [Application]
    public class MainApplication : Application
    {
        const String TUNE_ADVERTISER_ID = "877";
        const String TUNE_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";

        ITune tune;

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            //app init ...

            if (Build.VERSION.SdkInt >= BuildVersionCodes.IceCreamSandwich) {
                RegisterActivityLifecycleCallbacks (new TuneActivityLifecycleCallbacks ());
            }

            tune = Tune.Init(this.ApplicationContext, TUNE_ADVERTISER_ID, TUNE_CONVERSION_KEY);
            tune.SetFacebookEventLogging(true, false);
            tune.RegisterDeeplinkListener(new TuneDeeplinkListener());
        }
    }
}

