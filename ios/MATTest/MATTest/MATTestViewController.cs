using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MobileAppTrackerBinding;

namespace MATTest
{
	public partial class MATTestViewController : UIViewController
	{
		private const string MAT_ADVERTISER_ID = "877";
		private const string MAT_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
		private const string MAT_PACKAGE_NAME = "com.hasoffers.xamarinsample";

		private bool isDebugEnabled = false;
		private bool isAllowDuplicatesEnabled = false;

		private MobileAppTracker mat;

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

			// Perform any additional setup after loading the view, typically from a nib.

			btnStart.TouchUpInside += delegate {
				mat = MobileAppTracker.SharedManager;
				mat.InitTracker(MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
				mat.SetPackageName(MAT_PACKAGE_NAME);

				mat.Delegate = new TestMATDelegate();

				Console.WriteLine("MAT Tracker Started : adv id = {0}, conv key = {1}, package name = {2}", MAT_ADVERTISER_ID, MAT_CONVERSION_KEY, MAT_PACKAGE_NAME);
				Console.WriteLine("MAT SDK Data Params = " + mat.SdkDataParameters.ToString());
			};

			btnDebug.TouchUpInside += delegate {
				isDebugEnabled = !isDebugEnabled;
				mat.SetDebugMode(isDebugEnabled);
			};

			btnAllowDup.TouchUpInside += delegate {
				isAllowDuplicatesEnabled = !isAllowDuplicatesEnabled;
				mat.SetAllowDuplicates(isAllowDuplicatesEnabled);
			};

			btnPrintSDKParams.TouchUpInside += delegate {
				Console.WriteLine("MAT SDK Data Params = " + mat.SdkDataParameters.ToString());
			};

			btnInstall.TouchUpInside += delegate {
				mat.TrackInstall();
			};

			btnUpdate.TouchUpInside += delegate {
				mat.TrackUpdateWithReferenceId("ref11");
			};

			btnAction.TouchUpInside += delegate {
				mat.TrackAction("eventAction", false, "ref1", 1.99f, "GBP");
			};

			btnActionWithItems.TouchUpInside += delegate {

				MATEventItem item1 = MATEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "1", "2", "3", "4", "5");
				MATEventItem item2 = MATEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

				mat.TrackActionWithItems("eventItems", false, new MATEventItem[]{item1, item2}, "ref2", 0.89f, "CAD", 0);
			};

			btnActionWithReceipt.TouchUpInside += delegate {

				MATEventItem item1 = MATEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "6", "7", "8", "9", "10");
				MATEventItem item2 = MATEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);

				mat.TrackActionWithReceipt("eventReceipt", false, new MATEventItem[]{item1, item2}, "ref3", 132.6f, "RUB", 0, GetSampleiTunesIAPReceipt());
			};

			btnSetterMethods.TouchUpInside += delegate {

				Console.WriteLine("MAT SDK Data Params before calling setters = " + mat.SdkDataParameters.ToString());

				mat.SetODIN1("tempODIN1");
				mat.SetOpenUDID("tempOpenUDID");
				mat.SetMACAddress("tempMACAddress");
				mat.SetTrusteTPID("tempTrusteTPID");
				mat.SetUserId("tempUserId");
				mat.SetUIID("tempUIID");
				mat.SetCurrencyCode("tempCurrencyCode");
				mat.SetGender(1);
				mat.SetLocation(1.1,2.2);
				mat.SetLocationWithAltitude(3.3,4.4,5.5);
				mat.SetUseCookieTracking(false);
				mat.SetUseCookieTracking(false);
				mat.SetAppAdTracking(true);
				mat.SetAge(23);
				mat.SetJailbroken(false);
				mat.SetMATAdvertiserId("tempMATAdvId");
				mat.SetMATConversionKey("tempMATConvKey");
				mat.SetAppleAdvertisingIdentifier(new NSUuid("12345678-1234-1234-1234-123456789012"));
				mat.SetAppleVendorIdentifier(new NSUuid("12345678-1234-1234-1234-123456789012"));
				mat.SetFacebookUserId("tempFacebookId");
				mat.SetGoogleUserId("tempGoogleId");
				mat.SetTwitterUserId("tempTwitterId");

				Console.WriteLine("MAT SDK Data Params after calling setters = " + mat.SdkDataParameters.ToString());
			};
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}

		public string GetSampleiTunesIAPReceipt()
		{
			return "{\"signature\" = \"AiuR/oePW4lQq2qAFerYcL/lU7HB7rqPKoddrjnqLUqvLywbSukO3OUwWwiRGE8iFiNvaqVF2CaG8siBkfkP5KYaeiTHT2RNLCIKyCfhOIr4q0wYCKwxNp2vdo3S8b+4boeSAXzgzBHCR1S1hTN5LuoeRzDeIWHoYT66CBweqDetAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ==\";\"purchase-info\" = \"ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEzLTA2LTE5IDEzOjMyOjE5IEFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJInVuaXF1ZS1pZGVudGlmaWVyIiA9ICJjODU0OGI1YWExZjM5NDA2NmY1ZWEwM2Q3ZGU0YTBiYzdjMTEyZDk5IjsKCSJvcmlnaW5hbC10cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA3Nzk2MDgzNSI7CgkiYnZycyIgPSAiMS4xIjsKCSJ0cmFuc2FjdGlvbi1pZCIgPSAiMTAwMDAwMDA4MzE1MjA1NCI7CgkicXVhbnRpdHkiID0gIjEiOwoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzE2NzM5MzkwMDAiOwoJInVuaXF1ZS12ZW5kb3ItaWRlbnRpZmllciIgPSAiQTM3MjFCQzctNDA3Qi00QzcyLTg4RDAtMTdGNjIwRUMzNzEzIjsKCSJwcm9kdWN0LWlkIiA9ICJjb20uaGFzb2ZmZXJzLmluYXBwcHVyY2hhc2V0cmFja2VyMS5iYWxsIjsKCSJpdGVtLWlkIiA9ICI2NTMyMzA4MjkiOwoJImJpZCIgPSAiY29tLkhhc09mZmVycy5JbkFwcFB1cmNoYXNlVHJhY2tlcjEiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzNzU4MTM2NDcxMDIiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTMtMDgtMDYgMTg6Mjc6MjcgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTMtMDgtMDYgMTE6Mjc6MjcgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMy0wNi0xOSAyMDozMjoxOSBFdGMvR01UIjsKfQ==\";\"environment\" = \"Sandbox\";\"pod\" = \"100\";\"signing-status\" = \"0\";}";
		}
	}

	public class TestMATDelegate : MobileAppTrackerDelegate
	{
		public override void MobileAppTrackerDidSucceed (MobileAppTracker tracker, NSData data)
		{
			Console.WriteLine ("MAT DidSucceed: " + data.ToString ());
		}

		public override void MobileAppTrackerDidFail (MobileAppTracker tracker, NSError error)
		{
			Console.WriteLine ("MAT DidFail: " + error.ToString());
		}
	}
}

