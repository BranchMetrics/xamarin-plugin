using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobileAppTrackerBinding
{
	[BaseType (typeof (NSObject))]
	//[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] { typeof (MobileAppTrackerDelegate)})]
	public partial interface MobileAppTracker {

		[Static, Export ("sharedManager")]
		MobileAppTracker SharedManager { get; }

		[Export ("startTrackerWithMATAdvertiserId:MATConversionKey:")]
		void InitTracker (string aid, string key);

		[Export ("delegate", ArgumentSemantic.Assign)]
		MobileAppTrackerDelegate Delegate { get; set; }

//		[Export ("delegate"), NullAllowed]
//		NSObject WeakDelegate { get; set; }
//
//		[Wrap ("WeakDelegate")]
//		MobileAppTrackerDelegate Delegate { get; set; }

		[Export ("sdkDataParameters")]
		NSDictionary SdkDataParameters { get; }

		[Export ("setDebugMode:")]
		void SetDebugMode(bool enable);

		[Export ("setAllowDuplicateRequests:")]
		void SetAllowDuplicates(bool enable);

		[Export ("setAppleAdvertisingIdentifier:")]
		void SetAppleAdvertisingIdentifier(NSUuid advertisingId);

		[Export ("setAppleVendorIdentifier:")]
		void SetAppleVendorIdentifier(NSUuid vendorId);

		[Export ("setCurrencyCode:")]
		void SetCurrencyCode(string currencyCode);

		[Export ("setJailbroken:")]
		void SetJailbroken(bool jailBroken);

		[Export ("setMATAdvertiserId:")]
		void SetMATAdvertiserId(string advId);

		[Export ("setMATConversionKey:")]
		void SetMATConversionKey (string convKey);

		[Export ("setPackageName:")]
		void SetPackageName (string packageName);

		[Export ("setShouldAutoDetectJailbroken:")]
		void SetShouldAutoDetectJailbroken(bool autoDetect);

		[Export ("setShouldAutoGenerateAppleAdvertisingIdentifier:")]
		void SetShouldAutoGenerateAppleAdvertisingIdentifier (string advId);

		[Export ("setShouldAutoGenerateAppleVendorIdentifier:")]
		void SetShouldAutoGenerateAppleVendorIdentifier (string vendorId);

		[Export ("setMACAddress:")]
		void SetMACAddress (string mac);

		[Export ("setODIN1:")]
		void SetODIN1(string odin1);

		[Export ("setOpenUDID:")]
		void SetOpenUDID (string opneUDID);

		[Export ("setSiteId:")]
		void SetSiteId (string siteId);

		[Export ("setTrusteTPID:")]
		void SetTrusteTPID (string tpid);

		[Export ("setUserId:")]
		void SetUserId (string userId);

		[Export ("setFacebookUserId:")]
		void SetFacebookUserId (string facebookUserId);

		[Export ("setTwitterUserId:")]
		void SetTwitterUserId (string twitterUserId);

		[Export ("setGoogleUserId:")]
		void SetGoogleUserId (string googleUserId);

		[Export ("setUIID:")]
		void SetUIID(string uiid);

		[Export ("setAge:")]
		void SetAge(int age);

		[Export ("setGender:")]
		void SetGender (int gender);

		[Export ("setLatitude:longitude:")]
		void SetLocation (double latitude, double longitude);

		[Export ("setLatitude:longitude:altitude:")]
		void SetLocationWithAltitude (double latitude, double longitude, double altitude);

		[Export ("setAppAdTracking:")]
		void SetAppAdTracking (bool enable);

		[Export ("trackInstall")]
		void TrackInstall ();

		[Export ("trackInstallWithReferenceId:")]
		void TrackInstallWithReferenceId (string refId);

		[Export ("trackUpdate")]
		void TrackUpdate ();

		[Export ("trackUpdateWithReferenceId:")]
		void TrackUpdateWithReferenceId (string refId);

		[Export ("trackActionForEventIdOrName:eventIsId:referenceId:revenueAmount:currencyCode:")]
		void TrackAction (string eventIdOrName, bool isId, string refId, float revenueAmount, string currencyCode);

		[Export ("trackActionForEventIdOrName:eventIsId:eventItems:referenceId:revenueAmount:currencyCode:transactionState:")]
		void TrackActionWithItems (string eventIdOrName, bool isId, NSObject [] eventItems, string refId, float revenueAmount, string currencyCode, int transactionState);

		[Export ("trackActionForEventIdOrName:eventIsId:eventItems:referenceId:revenueAmount:currencyCode:transactionState:receipt:")]
		void TrackActionWithReceipt (string eventIdOrName, bool isId, NSObject [] eventItems, string refId, float revenueAmount, string currencyCode, int transactionState, NSData receipt);

		[Export ("setUseCookieTracking:")]
		void SetUseCookieTracking(bool enable);

		[Export ("setRedirectUrl:")]
		void SetRedirectUrl(string redirectUrl);

		[Export ("setTracking:advertiserId:offerId:publisherId:redirect:")]
		void SetTracking (string targetAppPackageName, string targetAppAdvertiserId, string targetAdvertiserOfferId, string targetAdvertiserPublisherId, bool shouldRedirect);

		[Export ("applicationDidOpenURL:sourceApplication:")]
		void ApplicationDidOpenURLFromSourceApplication (string urlString, string sourceApplication);
	}

//	[BaseType (typeof (NSObject))]
//	[Protocol] 
//	[Model]
//	public interface MobileAppTrackerDelegate {
//		[Abstract]
//		[Export ("mobileAppTracker:didSucceed:")]
//		void MobileAppTrackerDidSucceed (MobileAppTracker tracker, NSData data);
//
//		[Abstract]
//		[Export ("mobileAppTracker:didFail:")]
//		void MobileAppTrackerDidFail (MobileAppTracker tracker, NSError error);
//	}

	[BaseType (typeof (NSObject))]
	[Model]
	public partial interface MobileAppTrackerDelegate {

		[Export ("mobileAppTracker:didSucceedWithData:")]
		void MobileAppTrackerDidSucceed (MobileAppTracker tracker, NSData data);

		[Export ("mobileAppTracker:didFailWithError:")]
		void MobileAppTrackerDidFail (MobileAppTracker tracker, NSError error);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MATEventItem {

		[Export ("item", ArgumentSemantic.Copy)]
		string Item { get; set; }

		[Export ("unitPrice")]
		float UnitPrice { get; set; }

		[Export ("quantity")]
		int Quantity { get; set; }

		[Export ("revenue")]
		float Revenue { get; set; }

		[Export ("attribute1", ArgumentSemantic.Copy)]
		string Attribute1 { get; set; }

		[Export ("attribute2", ArgumentSemantic.Copy)]
		string Attribute2 { get; set; }

		[Export ("attribute3", ArgumentSemantic.Copy)]
		string Attribute3 { get; set; }

		[Export ("attribute4", ArgumentSemantic.Copy)]
		string Attribute4 { get; set; }

		[Export ("attribute5", ArgumentSemantic.Copy)]
		string Attribute5 { get; set; }

		[Static, Export ("eventItemWithName:unitPrice:quantity:revenue:")]
		MATEventItem EventItemWithName (string name, float unitPrice, int quantity, float revenue);

		[Static, Export ("eventItemWithName:attribute1:attribute2:attribute3:attribute4:attribute5:")]
		MATEventItem EventItemWithName (string name, string attribute1, string attribute2, string attribute3, string attribute4, string attribute5);

		[Static, Export ("eventItemWithName:unitPrice:quantity:revenue:attribute1:attribute2:attribute3:attribute4:attribute5:")]
		MATEventItem EventItemWithName (string name, float unitPrice, int quantity, float revenue, string attribute1, string attribute2, string attribute3, string attribute4, string attribute5);
	}

	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
}

