using System;
using CoreGraphics;
using AdSupport;
using Foundation;
using UIKit;
using MobileAppTracking;

namespace MATTest
{
    public partial class MATTestViewController : UIViewController
    {
        private const string MAT_ADVERTISER_ID = "877";
        private const string MAT_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
        private const string MAT_PACKAGE_NAME = "com.hasoffers.xamarinsample";

        TestMATDelegate matDelegate = new TestMATDelegate ();

        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public MATTestViewController ()
            : base (UserInterfaceIdiomIsPhone ? "MATTestViewController_iPhone" : "MATTestViewController_iPad", null)
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

            btnStart.TouchUpInside += delegate {
                MobileAppTracker.InitTracker(MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
                MobileAppTracker.SetPackageName(MAT_PACKAGE_NAME);
                MobileAppTracker.SetAppleAdvertisingIdentifier(ASIdentifierManager.SharedManager.AdvertisingIdentifier, ASIdentifierManager.SharedManager.IsAdvertisingTrackingEnabled);
                MobileAppTracker.AutomateIapEventMeasurement(true);
                MobileAppTracker.SetFacebookEventLogging(true, false);

                Console.WriteLine("MAT Tracker Started : adv id = {0}, conv key = {1}, package name = {2}", MAT_ADVERTISER_ID, MAT_CONVERSION_KEY, MAT_PACKAGE_NAME);
            };

            btnDelegate.TouchUpInside += delegate {
                Console.WriteLine("matDelegate = " + matDelegate);
                MobileAppTracker.SetDelegate(matDelegate);
                MobileAppTracker.CheckForDeferredDeeplink(matDelegate);
            };

            btnDebug.TouchUpInside += delegate {
                MobileAppTracker.SetDebugMode(true);
            };

            btnAllowDup.TouchUpInside += delegate {
                MobileAppTracker.SetAllowDuplicates(true);
            };

            btnSession.TouchUpInside += delegate {
                MobileAppTracker.MeasureSession();
            };

            btnAction.TouchUpInside += delegate {
                MobileAppTracker.MeasureEventName("eventAction1");

                MATEvent evt = MATEvent.EventWithName("eventAction2");
                evt.RefId = "ref1";
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithName("eventAction3");
                evt.RefId = "ref2";
                evt.Revenue = 1.99f;
                evt.CurrencyCode = "GBP";
                MobileAppTracker.MeasureEvent(evt);

                MobileAppTracker.MeasureEventId(932851438);

                evt = MATEvent.EventWithId(932851438);
                evt.RefId = "ref3";
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithId(932851438);
                evt.RefId = "ref4";
                evt.Revenue = 1.99f;
                evt.CurrencyCode = "GBP";
                MobileAppTracker.MeasureEvent(evt);
            };

            btnActionWithItems.TouchUpInside += delegate {

                MATEventItem item1 = MATEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "1", "2", "3", "4", "5");
                MATEventItem item2 = MATEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

                MATEvent evt = MATEvent.EventWithName("eventItems");
                evt.EventItems = new MATEventItem[] { item1, item2 };
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithName("eventItems");
                evt.EventItems = new MATEventItem[] { item1, item2 };
                evt.RefId = "ref5";
                evt.Attribute1 = "attr1";
                evt.Attribute2 = "attr2";
                evt.Attribute3 = "attr3";
                evt.Attribute4 = "attr4";
                evt.Attribute5 = "attr5";
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithName("eventItems");
                evt.EventItems = new MATEventItem[] { item1, item2 };
                evt.RefId = "ref6";
                evt.Revenue = 0.89f;
                evt.CurrencyCode = "CAD";
                evt.TransactionState = 0;
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithId(932851438);
                evt.EventItems = new MATEventItem[] { item1, item2 };
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithId(932851438);
                evt.EventItems = new MATEventItem[] { item1, item2 };
                evt.RefId = "ref7";
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithId(932851438);
                evt.EventItems = new MATEventItem[] { item1, item2 };
                evt.RefId = "ref8";
                evt.Revenue = 0.89f;
                evt.CurrencyCode = "CAD";
                evt.TransactionState = 0;
                evt.ContentType = "testContentType";
                evt.ContentId = "123456789";
                evt.SearchString = "testSearchString";
                MobileAppTracker.MeasureEvent(evt);
            };

            btnActionWithReceipt.TouchUpInside += delegate {

                MATEventItem item1 = MATEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "6", "7", "8", "9", "10");
                MATEventItem item2 = MATEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

                MATEvent evt = MATEvent.EventWithName("eventReceipt");
                evt.EventItems = new MATEventItem[] { item1, item2 };
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
                MobileAppTracker.MeasureEvent(evt);

                evt = MATEvent.EventWithId(932851438);
                evt.EventItems = new MATEventItem[] { item1, item2 };
                evt.RefId = "ref10";
                evt.Revenue = 132.6f;
                evt.CurrencyCode = "RUB";
                evt.TransactionState = 0;
                evt.Receipt = NSData.FromString(GetSampleiTunesIAPReceipt());
                MobileAppTracker.MeasureEvent(evt);
            };

            btnSetterMethods.TouchUpInside += delegate {

                Console.WriteLine("MAT setter methods");

                MobileAppTracker.SetTRUSTeId("tempTrusteTPID");
                MobileAppTracker.SetUserId("tempUserId");
                MobileAppTracker.SetUserEmail("temp@temp.com");
                MobileAppTracker.SetUserName("tempUserName");
                MobileAppTracker.SetPhoneNumber("123-456-7890");
                MobileAppTracker.SetCurrencyCode("GBP");
                MobileAppTracker.SetGender(1);
                MobileAppTracker.SetLocation(1.1,2.2);
                MobileAppTracker.SetLocationWithAltitude(3.3,4.4,5.5);
                MobileAppTracker.SetUseCookieTracking(false);
                MobileAppTracker.SetUseCookieTracking(false);
                MobileAppTracker.SetAppAdTracking(true);
                MobileAppTracker.SetAge(23);
                MobileAppTracker.SetJailbroken(false);
                MobileAppTracker.SetAppleAdvertisingIdentifier(ASIdentifierManager.SharedManager.AdvertisingIdentifier, ASIdentifierManager.SharedManager.IsAdvertisingTrackingEnabled);
                MobileAppTracker.SetAppleVendorIdentifier(UIDevice.CurrentDevice.IdentifierForVendor);
                MobileAppTracker.SetFacebookUserId("tempFacebookId");
                MobileAppTracker.SetGoogleUserId("tempGoogleId");
                MobileAppTracker.SetTwitterUserId("tempTwitterId");

                MobileAppTracker.SetExistingUser(false);
                MobileAppTracker.SetPayingUser(false);
            };

            btnGetterMethods.TouchUpInside += delegate {

                Console.WriteLine("MatId        = " + MobileAppTracker.MatId);
                Console.WriteLine("OpenLogId    = " + MobileAppTracker.OpenLogId);
                Console.WriteLine("IsPayingUser = " + MobileAppTracker.IsPayingUser);
            };
        }

        public string GetSampleiTunesIAPReceipt()
        {
            return "{\"signature\" = \"AiuR/oePW4lQq2qAFerYcL/lU7HB7rqPKoddrjnqLUqvLywbSukO3OUwWwiRGE8iFiNvaqVF2CaG8siBkfkP5KYaeiTHT2RNLCIKyCfhOIr4q0wYCKwxNp2vdo3S8b+4boeSAXzgzBHCR1S1hTN5LuoeRzDeIWHoYT66CBweqDetAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ==\";\"purchase-info\" = \"ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEzLTA2LTE5IDEzOjMyOjE5IEFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJInVuaXF1ZS1pZGVudGlmaWVyIiA9ICJjODU0OGI1YWExZjM5NDA2NmY1ZWEwM2Q3ZGU0YTBiYzdjMTEyZDk5IjsKCSJvcmlnaW5hbC10cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA3Nzk2MDgzNSI7CgkiYnZycyIgPSAiMS4xIjsKCSJ0cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA4MzE1MjA1NCI7CgkicXVhbnRpdHkiID0gIjEiOwoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzE2NzM5MzkwMDAiOwoJInVuaXF1ZS12ZW5kb3ItaWRlbnRpZmllciIgPSAiQTM3MjFCQzctNDA3Qi00QzcyLTg4RDAtMTdGNjIwRUMzNzEzIjsKCSJwcm9kdWN0LWlkIiA9ICJjb20uaGFzb2ZmZXJzLmluYXBwcHVyY2hhc2V0cmFja2VyMS5iYWxsIjsKCSJpdGVtLWlkIiA9ICI2NTMyMzA4MjkiOwoJImJpZCIgPSAiY29tLkhhc09mZmVycy5JbkFwcFB1cmNoYXNlVHJhY2tlcjEiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzU4MTM2NDcxMDIiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTMtMDgtMDYgMTg6Mjc6MjcgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTMtMDgtMDYgMTE6Mjc6MjcgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMy0wNi0xOSAyMDozMjoxOSBFdGMvR01UIjsKfQ==\";\"environment\" = \"Sandbox\";\"pod\" = \"100\";\"signing-status\" = \"0\";}";
        }
    }

    public class TestMATDelegate : MobileAppTrackerDelegate
    {
        public override void MobileAppTrackerDidSucceed (NSData data)
        {
            Console.WriteLine ("MAT DidSucceed: " + NSString.FromData(data, NSStringEncoding.UTF8));
        }

        public override void MobileAppTrackerDidFail (NSError error)
        {
            Console.WriteLine ("MAT DidFail: error = " + error.Code + ", " + error.LocalizedDescription);
        }

        public override void MobileAppTrackerEnqueuedAction (string referenceId)
        {
            Console.WriteLine ("MAT EnqueuedAction: advertiserRefId = " + referenceId);
        }

        public override void MobileAppTrackerDidReceiveDeeplink (string deeplink)
        {
            Console.WriteLine ("MAT DidReceiveDeeplink: deeplink = " + deeplink);
            MobileAppTracker.SetDeeplink(deeplink, "xamarin test app");
        }

        public override void MobileAppTrackerDidFailDeeplinkWithError (NSError error)
        {
            Console.WriteLine ("MAT DidFailDeeplinkWithError: error = " + error.Code + ", " + error.LocalizedDescription);
        }
    }
}