using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace MobileAppTracking
{
    [BaseType (typeof (NSObject))]
    public interface MobileAppTracker {

        [Static, Export ("initializeWithMATAdvertiserId:MATConversionKey:")]
        void InitTracker (string aid, string key);

        [Static, Export ("setDelegate:")]
        void SetDelegate(MobileAppTrackerDelegate matDelegate);

        [Static, Export ("automateIapEventMeasurement:")]
        void AutomateIapEventMeasurement(bool automate);

        [Static, Export ("checkForDeferredDeeplink:")]
        void CheckForDeferredDeeplink(MobileAppTrackerDelegate matDelegate);

        [Static, Export ("matId")]
        string MatId { get; }

        [Static, Export ("openLogId")]
        string OpenLogId { get; }

        [Static, Export ("isPayingUser")]
        bool IsPayingUser { get; }

        [Static, Export ("setDebugMode:")]
        void SetDebugMode(bool enable);

        [Static, Export ("setAllowDuplicateRequests:")]
        void SetAllowDuplicates(bool enable);

        [Static, Export ("setAppleAdvertisingIdentifier:advertisingTrackingEnabled:")]
        void SetAppleAdvertisingIdentifier(NSUuid advertisingId, bool trackingEnabled);

        [Static, Export ("setAppleVendorIdentifier:")]
        void SetAppleVendorIdentifier(NSUuid vendorId);

        [Static, Export ("setCurrencyCode:")]
        void SetCurrencyCode(string currencyCode);

        [Static, Export ("applicationDidOpenURL:sourceApplication:")]
        void SetDeeplink(string deeplink, string sourceApplication);

        [Static, Export ("setExistingUser:")]
        void SetExistingUser(bool existing);

        [Static, Export ("setFacebookEventLogging:limitEventAndDataUsage:")]
        void SetFacebookEventLogging(bool enable, bool limitEventAndDataUsage);

        [Static, Export ("setPayingUser:")]
        void SetPayingUser(bool paying);

        [Static, Export ("setJailbroken:")]
        void SetJailbroken(bool jailBroken);

        [Static, Export ("setPackageName:")]
        void SetPackageName (string packageName);

        [Static, Export ("setShouldAutoDetectJailbroken:")]
        void SetShouldAutoDetectJailbroken(bool autoDetect);

        [Static, Export ("setShouldAutoGenerateAppleVendorIdentifier:")]
        void SetShouldAutoGenerateAppleVendorIdentifier (string vendorId);

        [Static, Export ("setSiteId:")]
        void SetSiteId (string siteId);

        [Static, Export ("setTRUSTeId:")]
        void SetTRUSTeId (string tpid);

        [Static, Export ("setUserId:")]
        void SetUserId (string userId);

        [Static, Export ("setUserEmail:")]
        void SetUserEmail (string userEmail);

        [Static, Export ("setUserName:")]
        void SetUserName (string userName);

        [Static, Export ("setPhoneNumber:")]
        void SetPhoneNumber (string phoneNumber);

        [Static, Export ("setFacebookUserId:")]
        void SetFacebookUserId (string facebookUserId);

        [Static, Export ("setTwitterUserId:")]
        void SetTwitterUserId (string twitterUserId);

        [Static, Export ("setGoogleUserId:")]
        void SetGoogleUserId (string googleUserId);

        [Static, Export ("setAge:")]
        void SetAge(int age);

        [Static, Export ("setGender:")]
        void SetGender (int gender);

        [Static, Export ("setLatitude:longitude:")]
        void SetLocation (double latitude, double longitude);

        [Static, Export ("setLatitude:longitude:altitude:")]
        void SetLocationWithAltitude (double latitude, double longitude, double altitude);

        [Static, Export ("setAppAdTracking:")]
        void SetAppAdTracking (bool enable);

        [Static, Export ("measureSession")]
        void MeasureSession ();

        [Static, Export ("measureEvent:")]
        void MeasureEvent (MATEvent eventName);

        [Static, Export ("measureEventName:")]
        void MeasureEventName (string eventName);

        [Static, Export ("measureEventId:")]
        void MeasureEventId (int eventId);

        [Static, Export ("setUseCookieTracking:")]
        void SetUseCookieTracking(bool enable);

        [Static, Export ("setRedirectUrl:")]
        void SetRedirectUrl(string redirectUrl);

        [Static, Export ("startAppToAppTracking:advertiserId:offerId:publisherId:redirect:")]
        void StartAppToAppTracking (string targetAppPackageName, string targetAppAdvertiserId, string targetAdvertiserOfferId, string targetAdvertiserPublisherId, bool shouldRedirect);

        [Static, Export ("applicationDidOpenURL:sourceApplication:")]
        void ApplicationDidOpenURLFromSourceApplication (string urlString, string sourceApplication);
    }

    [BaseType (typeof (NSObject))]
    [Model][Protocol]
    public interface MobileAppTrackerDelegate {

        [Export ("mobileAppTrackerDidSucceedWithData:")]
        void MobileAppTrackerDidSucceed (NSData data);

        [Export ("mobileAppTrackerDidFailWithError:")]
        void MobileAppTrackerDidFail (NSError error);

        [Export ("mobileAppTrackerEnqueuedActionWithReferenceId:")]
        void MobileAppTrackerEnqueuedAction (string referenceId);

        [Export ("mobileAppTrackerDidReceiveDeeplink:")]
        void MobileAppTrackerDidReceiveDeeplink (string deeplink);

        [Export ("mobileAppTrackerDidFailDeeplinkWithError:")]
        void MobileAppTrackerDidFailDeeplinkWithError (NSError error);

        [Export ("mobileAppTrackerDidDisplayiAd")]
        void MobileAppTrackerDidDisplayiAd ();

        [Export ("mobileAppTrackerDidRemoveiAd")]
        void MobileAppTrackerDidRemoveiAd ();

        [Export ("mobileAppTrackerFailedToReceiveiAdWithError:")]
        void MobileAppTrackerFailedToReceiveiAdWithError (NSError error);
    }

    [BaseType (typeof (NSObject))]
    public interface MATEventItem {

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

    [BaseType (typeof (NSObject))]
    public interface MATEvent {

        [Export ("eventName", ArgumentSemantic.Copy)]
        string EventName { get; }

        [Export ("eventId")]
        int EventId { get; }

        [Export ("level")]
        int Level { get; set; }

        [Export ("quantity")]
        int Quantity { get; set; }

        [Export ("revenue")]
        float Revenue { get; set; }

        [Export ("rating")]
        float Rating { get; set; }

        [Export ("transactionState")]
        int TransactionState { get; set; }

        [Export ("eventItems", ArgumentSemantic.Copy)]
        NSObject[] EventItems { get; set; }

        [Export ("receipt", ArgumentSemantic.Copy)]
        NSData Receipt { get; set; }

        [Export ("date1", ArgumentSemantic.Copy)]
        NSDate Date1 { get; set; }

        [Export ("date2", ArgumentSemantic.Copy)]
        NSDate Date2 { get; set; }

        [Export ("refId", ArgumentSemantic.Copy)]
        string RefId { get; set; }

        [Export ("currencyCode", ArgumentSemantic.Copy)]
        string CurrencyCode { get; set; }

        [Export ("contentType", ArgumentSemantic.Copy)]
        string ContentType { get; set; }

        [Export ("contentId", ArgumentSemantic.Copy)]
        string ContentId { get; set; }

        [Export ("searchString", ArgumentSemantic.Copy)]
        string SearchString { get; set; }

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

        [Static, Export ("eventWithName:")]
        MATEvent EventWithName (string name);

        [Static, Export ("eventWithId:")]
        MATEvent EventWithId (int eventId);
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