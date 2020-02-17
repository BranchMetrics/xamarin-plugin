using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace TuneSDK
{
    public delegate void TuneDebugCallback (NSString message);

    [BaseType (typeof (NSObject))]
    [Protocol]
    public interface Tune {

        [Static, Export ("setDebugLogVerbose:")]
        void SetDebugLogVerbose (bool enable);

        [Static, Export ("setDebugLogCallback:")]
        void SetDebugLogCallBack (TuneDebugCallback callback);

        [Static, Export ("initializeWithTuneAdvertiserId:tuneConversionKey:")]
        void InitTracker (string aid, string key);

        [Static, Export ("initializeWithTuneAdvertiserId:tuneConversionKey:tunePackageName:")]
        void InitTracker (string aid, string key, string packageName, bool wearable, NSDictionary config);

        /* Deeplinking */

        [Static, Export ("registerDeeplinkListener:")]
        void RegisterDeeplinkListener (TuneDelegate tuneDelegate);

        [Static, Export ("unregisterDeeplinkListener")]
        void UnregisterDeeplinkListener ();

        [Static, Export ("isTuneLink:")]
        bool IsTuneLink (string linkURL);

        [Static, Export ("registerCustomTuneLinkDomain:")]
        void RegisterCustomTuneLinkDomain (string linkDomain);

        /* Tune Behavior Flags */

        [Static, Export ("automateInAppPurchaseEventMeasurement:")]
        void AutomateIapEventMeasurement (bool automate);

        [Static, Export ("setFacebookEventLogging:limitEventAndDataUsage:")]
        void SetFacebookEventLogging (bool enable, bool limitEventAndDataUsage);

        /* AppDelegate methods */

        [Static, Export ("handleOpenURL:sourceApplication:")]
        void HandleOpenURL (string deeplink, UIApplication sourceApplication);

        [Static, Export ("handleContinueUserActivity:restorationHandler:")]
        void HandleContinueUserActivity (NSUserActivity userActivity, UIApplicationRestorationHandler restorationHandler);

        /* Tune Device Profile */

        [Static, Export ("setExistingUser:")]
        void SetExistingUser (bool existing);

        [Static, Export ("setJailbroken:")]
        void SetJailbroken (bool jailBroken);

        [Static, Export ("tuneId")]
        string TuneId { get; }

        [Static, Export ("openLogId")]
        string OpenLogId { get; }

        [Static, Export ("isPayingUser")]
        bool IsPayingUser { get; }

        [Static, Export ("setPayingUser:")]
        void SetPayingUser(bool paying);

        [Static, Export ("setUserId:")]
        void SetUserId (string userId);

        /* Tune Event Measurement */

        [Static, Export ("measureSession")]
        void MeasureSession ();

        [Static, Export ("measureEvent:")]
        void MeasureEvent (TuneEvent eventName);

        [Static, Export ("measureEventName:")]
        void MeasureEventName (string eventName);
    }

    [BaseType (typeof (NSObject))]
    [Model][Protocol]
    public interface TuneDelegate {

        [Export ("tuneDidReceiveDeeplink:")]
        void TuneDidReceiveDeeplink (string deeplink);

        [Export ("tuneDidFailDeeplinkWithError:")]
        void TuneDidFailDeeplinkWithError (NSError error);
    }

    [BaseType (typeof (NSObject))]
    [Protocol]
    public interface TuneEventItem {

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
        TuneEventItem EventItemWithName (string name, float unitPrice, int quantity, float revenue);

        [Static, Export ("eventItemWithName:attribute1:attribute2:attribute3:attribute4:attribute5:")]
        TuneEventItem EventItemWithName (string name, string attribute1, string attribute2, string attribute3, string attribute4, string attribute5);

        [Static, Export ("eventItemWithName:unitPrice:quantity:revenue:attribute1:attribute2:attribute3:attribute4:attribute5:")]
        TuneEventItem EventItemWithName (string name, float unitPrice, int quantity, float revenue, string attribute1, string attribute2, string attribute3, string attribute4, string attribute5);
    }

    [BaseType (typeof (NSObject))]
    [Protocol]
    public interface TuneEvent {

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
        TuneEvent EventWithName (string name);

        [Static, Export ("eventWithId:")]
        TuneEvent EventWithId (int eventId);
    }
}
