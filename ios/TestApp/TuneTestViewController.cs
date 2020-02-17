using System;
using CoreGraphics;
using AdSupport;
using Foundation;
using UIKit;
using TuneSDK;

namespace TestApp
{
    public partial class TuneTestViewController : UIViewController
    {
        private const string TUNE_ADVERTISER_ID = "877";
        private const string TUNE_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
        private const string TUNE_PACKAGE_NAME = "com.hasoffers.xamarinsample";

        TestTuneDelegate tuneDelegate = new TestTuneDelegate ();

        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public TuneTestViewController ()
            : base (UserInterfaceIdiomIsPhone ? "TuneTestViewController_iPhone" : "TuneTestViewController_iPad", null)
        {
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            btnDelegate.TouchUpInside += delegate {
                Console.WriteLine("tuneDelegate = " + tuneDelegate);
                Tune.RegisterDeeplinkListener(tuneDelegate);
            };

            btnDebug.TouchUpInside += delegate {
                Tune.SetDebugLogVerbose (true);
                Tune.SetDebugLogCallBack ((message) => {
                    Console.WriteLine (message);
                });
            };

            btnSession.TouchUpInside += delegate {
                Tune.MeasureSession();
            };

            btnAction.TouchUpInside += delegate {
                Tune.MeasureEventName("eventAction1");

                TuneEvent evt = TuneEvent.EventWithName("eventAction2");
                evt.RefId = "ref1";
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithName("eventAction3");
                evt.RefId = "ref2";
                evt.Revenue = 1.99f;
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.RefId = "ref3";
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.RefId = "ref4";
                evt.Revenue = 1.99f;
                evt.CurrencyCode = "GBP";
                Tune.MeasureEvent(evt);
            };

            btnActionWithItems.TouchUpInside += delegate {

                TuneEventItem item1 = TuneEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "1", "2", "3", "4", "5");
                TuneEventItem item2 = TuneEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

                TuneEvent evt = TuneEvent.EventWithName("eventItems");
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithName("eventItems");
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref5";
                evt.Attribute1 = "attr1";
                evt.Attribute2 = "attr2";
                evt.Attribute3 = "attr3";
                evt.Attribute4 = "attr4";
                evt.Attribute5 = "attr5";
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithName("eventItems");
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref6";
                evt.Revenue = 0.89f;
                evt.CurrencyCode = "CAD";
                evt.TransactionState = 0;
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref7";
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref8";
                evt.Revenue = 0.89f;
                evt.CurrencyCode = "CAD";
                evt.TransactionState = 0;
                evt.ContentType = "testContentType";
                evt.ContentId = "123456789";
                evt.SearchString = "testSearchString";
                Tune.MeasureEvent(evt);
            };

            btnActionWithReceipt.TouchUpInside += delegate {

                TuneEventItem item1 = TuneEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "6", "7", "8", "9", "10");
                TuneEventItem item2 = TuneEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

                TuneEvent evt = TuneEvent.EventWithName("eventReceipt");
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref9";
                evt.Revenue = 132.6f;
                evt.CurrencyCode = "RUB";
                evt.TransactionState = 0;
                evt.Rating = 4.5f;
                evt.Quantity = 1;
                evt.Level = 9;
                evt.Date1 = NSDate.Now;
                evt.Date2 = NSDate.FromTimeIntervalSinceNow(86400);
                evt.Receipt = NSData.FromString(GetSampleiTunesIAPReceipt());
                Tune.MeasureEvent(evt);

                evt = TuneEvent.EventWithId(932851438);
                evt.EventItems = new TuneEventItem[] { item1, item2 };
                evt.RefId = "ref10";
                evt.Revenue = 132.6f;
                evt.CurrencyCode = "RUB";
                evt.TransactionState = 0;
                evt.Receipt = NSData.FromString(GetSampleiTunesIAPReceipt());
                Tune.MeasureEvent(evt);
            };

            btnSetterMethods.TouchUpInside += delegate {

                Console.WriteLine("TUNE setter methods");

                Tune.SetUserId("tempUserId");
                Tune.SetJailbroken(false);

                Tune.SetExistingUser(false);
                Tune.SetPayingUser(false);
            };

            btnGetterMethods.TouchUpInside += delegate {
                Console.WriteLine("MatId        = " + Tune.TuneId);
                Console.WriteLine("OpenLogId    = " + Tune.OpenLogId);
                Console.WriteLine("IsPayingUser = " + Tune.IsPayingUser);
            };
        }

        public string GetSampleiTunesIAPReceipt()
        {
            return "{\"signature\" = \"AiuR/oePW4lQq2qAFerYcL/lU7HB7rqPKoddrjnqLUqvLywbSukO3OUwWwiRGE8iFiNvaqVF2CaG8siBkfkP5KYaeiTHT2RNLCIKyCfhOIr4q0wYCKwxNp2vdo3S8b+4boeSAXzgzBHCR1S1hTN5LuoeRzDeIWHoYT66CBweqDetAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ==\";\"purchase-info\" = \"ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEzLTA2LTE5IDEzOjMyOjE5IEFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJInVuaXF1ZS1pZGVudGlmaWVyIiA9ICJjODU0OGI1YWExZjM5NDA2NmY1ZWEwM2Q3ZGU0YTBiYzdjMTEyZDk5IjsKCSJvcmlnaW5hbC10cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA3Nzk2MDgzNSI7CgkiYnZycyIgPSAiMS4xIjsKCSJ0cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA4MzE1MjA1NCI7CgkicXVhbnRpdHkiID0gIjEiOwoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzE2NzM5MzkwMDAiOwoJInVuaXF1ZS12ZW5kb3ItaWRlbnRpZmllciIgPSAiQTM3MjFCQzctNDA3Qi00QzcyLTg4RDAtMTdGNjIwRUMzNzEzIjsKCSJwcm9kdWN0LWlkIiA9ICJjb20uaGFzb2ZmZXJzLmluYXBwcHVyY2hhc2V0cmFja2VyMS5iYWxsIjsKCSJpdGVtLWlkIiA9ICI2NTMyMzA4MjkiOwoJImJpZCIgPSAiY29tLkhhc09mZmVycy5JbkFwcFB1cmNoYXNlVHJhY2tlcjEiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzU4MTM2NDcxMDIiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTMtMDgtMDYgMTg6Mjc6MjcgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTMtMDgtMDYgMTE6Mjc6MjcgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMy0wNi0xOSAyMDozMjoxOSBFdGMvR01UIjsKfQ==\";\"environment\" = \"Sandbox\";\"pod\" = \"100\";\"signing-status\" = \"0\";}";
        }
    }

    public class TestTuneDelegate : TuneDelegate
    {
        public override void TuneDidReceiveDeeplink (string deeplink)
        {
            Console.WriteLine ("TUNE DidReceiveDeeplink: deeplink = " + deeplink);
        }

        public override void TuneDidFailDeeplinkWithError (NSError error)
        {
            Console.WriteLine ("TUNE DidFailDeeplinkWithError: error = " + error.Code + ", " + error.LocalizedDescription);
        }
    }
}