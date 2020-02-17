using System;
using TuneSDK;

namespace TestApp
{
    public class TuneDeeplinkListener : Java.Lang.Object, ITuneDeeplinkListener 
    {
        public TuneDeeplinkListener ()
        {
        }

        public void DidReceiveDeeplink(string deeplink)
        {
            Console.WriteLine ("TUNE DidReceiveDeeplink: " + deeplink);
            // Pass deferred deeplink value to TUNE
            Tune.Instance.ReferralUrl = deeplink;
            // TODO: handle deeplink redirection
        }

        public void DidFailDeeplink(string error)
        {
            Console.WriteLine ("TUNE DidFailDeeplink: error = " + error);
        }
    }
}

