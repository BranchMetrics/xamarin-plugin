using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace TuneSDK
{
    // This declares the callback signature for the block:
    public delegate void TuneCallback ();
    public delegate void DeepAction (NSDictionary extraData);

    [BaseType (typeof (NSObject))]
    [Protocol]
    public interface Tune {

        [Static, Export ("initializeWithTuneAdvertiserId:tuneConversionKey:")]
        void InitTracker (string aid, string key);

        [Static, Export ("initializeWithTuneAdvertiserId:tuneConversionKey:tunePackageName:wearable:configuration:")]
        void InitTracker (string aid, string key, string packageName, bool wearable, NSDictionary config);

        [Static, Export ("setDelegate:")]
        void SetDelegate(TuneDelegate tuneDelegate);

        /* Deeplinking */

        [Static, Export ("checkForDeferredDeeplink:")]
        void CheckForDeferredDeeplink(TuneDelegate tuneDelegate);

        [Static, Export ("registerDeeplinkListener:")]
        void RegisterDeeplinkListener (TuneDelegate tuneDelegate);

        [Static, Export ("unregisterDeeplinkListener")]
        void UnregisterDeeplinkListener ();

        [Static, Export ("isTuneLink:")]
        bool IsTuneLink (string linkURL);

        [Static, Export ("registerCustomTuneLinkDomain:")]
        void RegisterCustomTuneLinkDomain (string linkDomain);

        /* Tune Behavior Flags */

        [Static, Export ("automateIapEventMeasurement:")]
        void AutomateIapEventMeasurement (bool automate);

        [Static, Export ("setFacebookEventLogging:limitEventAndDataUsage:")]
        void SetFacebookEventLogging (bool enable, bool limitEventAndDataUsage);

        [Static, Export ("setShouldAutoCollectAppleAdvertisingIdentifier:")]
        void SetShouldAutoCollectAppleAdvertisingIdentifier (bool autoCollect);

        [Static, Export ("setShouldAutoCollectDeviceLocation:")]
        void SetShouldAutoCollectDeviceLocation (bool autoCollect);

        [Static, Export ("setShouldAutoDetectJailbroken:")]
        void SetShouldAutoDetectJailbroken (bool autoDetect);

        [Static, Export ("setShouldAutoGenerateAppleVendorIdentifier:")]
        void SetShouldAutoGenerateAppleVendorIdentifier (string vendorId);

        /* AppDelegate methods */

        [Static, Export ("handleOpenURL:sourceApplication:")]
        void HandleOpenURL (string deeplink, UIApplication sourceApplication);

        [Static, Export ("handleContinueUserActivity:restorationHandler:")]
        void HandleContinueUserActivity (NSUserActivity userActivity, UIApplicationRestorationHandler restorationHandler);

        /* Tune Device Profile */

        [Static, Export ("setExistingUser:")]
        void SetExistingUser (bool existing);

        [Static, Export ("setAppleAdvertisingIdentifier:advertisingTrackingEnabled:")]
        void SetAppleAdvertisingIdentifier (NSUuid advertisingId, bool trackingEnabled);

        [Static, Export ("setAppleVendorIdentifier:")]
        void SetAppleVendorIdentifier (NSUuid vendorId);

        [Static, Export ("setCurrencyCode:")]
        void SetCurrencyCode (string currencyCode);

        [Static, Export ("setJailbroken:")]
        void SetJailbroken (bool jailBroken);

        [Static, Export ("setPackageName:")]
        void SetPackageName (string packageName);

        [Static, Export ("tuneId")]
        string TuneId { get; }

        [Static, Export ("openLogId")]
        string OpenLogId { get; }

        [Static, Export ("isPayingUser")]
        bool IsPayingUser { get; }

        [Static, Export ("setDebugMode:")]
        void SetDebugMode(bool enable);

        [Static, Export ("setPayingUser:")]
        void SetPayingUser(bool paying);

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

        [Static, Export ("setLocation:")]
        void SetLocation (TuneLocation location);

        [Static, Export ("setAppAdMeasurement:")]
        void SetAppAdMeasurement (bool enable);

        /* Tune Event Measurement */

        [Static, Export ("measureSession")]
        void MeasureSession ();

        [Static, Export ("measureEvent:")]
        void MeasureEvent (TuneEvent eventName);

        [Static, Export ("measureEventName:")]
        void MeasureEventName (string eventName);

        [Static, Export ("measureEventId:")]
        void MeasureEventId (int eventId);

        [Static, Export ("setUseCookieMeasurement:")]
        void SetUseCookieMeasurement (bool enable);

        [Static, Export ("setRedirectUrl:")]
        void SetRedirectUrl(string redirectUrl);

        [Static, Export ("startAppToAppMeasurement:advertiserId:offerId:publisherId:redirect:")]
        void StartAppToAppMeasurement (string targetAppPackageName, string targetAppAdvertiserId, string targetAdvertiserOfferId, string targetAdvertiserPublisherId, bool shouldRedirect);

        /* Custom Profile API */

        [Static, Export ("registerCustomProfileString:")]
        void RegisterCustomProfileString (string variableName);

        [Static, Export ("registerCustomProfileString:withDefault:")]
        void RegisterCustomProfileString (string variableName, string defaultValue);

        [Static, Export ("registerCustomProfileString:hashed:")]
        void RegisterCustomProfileString (string variableName, bool shouldHash);

        [Static, Export ("registerCustomProfileString:withDefault:hashed:")]
        void RegisterCustomProfileString (string variableName, string defaultValue, bool shouldHash);

        [Static, Export ("registerCustomProfileBoolean:")]
        void RegisterCustomProfileBoolean (bool variableName);

        [Static, Export ("registerCustomProfileBoolean:withDefault:")]
        void RegisterCustomProfileBoolean (string variableName, NSNumber defaultValue);

        [Static, Export ("registerCustomProfileDateTime:")]
        void RegisterCustomProfileDateTime (string variableName);

        [Static, Export ("registerCustomProfileDateTime:withDefault:")]
        void RegisterCustomProfileDateTime (string variableName, NSDate defaultValue);

        [Static, Export ("registerCustomProfileNumber:")]
        void RegisterCustomProfileNumber (string variableName);

        [Static, Export ("registerCustomProfileNumber:withDefault:")]
        void RegisterCustomProfileNumber (string variableName, NSNumber defaultValue);

        [Static, Export ("registerCustomProfileGeolocation:")]
        void RegisterCustomProfileGeolocation (string variableName);

        [Static, Export ("registerCustomProfileGeolocation:withDefault:")]
        void RegisterCustomProfileGeolocation (string variableName, TuneLocation defaultValue);

        [Static, Export ("registerCustomProfileVersion:")]
        void RegisterCustomProfileVersion (string variableName);

        [Static, Export ("registerCustomProfileVersion:withDefault:")]
        void RegisterCustomProfileVersion (string variableName, string defaultValue);

        [Static, Export ("setCustomProfileStringValue:forVariable:")]
        void SetCustomProfileStringValue (string value, string name);

        [Static, Export ("setCustomProfileBooleanValue:forVariable:")]
        void SetCustomProfileBooleanValue (NSNumber value, string name);

        [Static, Export ("setCustomProfileDateTimeValue:forVariable:")]
        void SetCustomProfileDateTimeValue (NSDate value, string name);

        [Static, Export ("setCustomProfileNumberValue:forVariable:")]
        void SetCustomProfileNumberValue (NSNumber value, string name);

        [Static, Export ("setCustomProfileGeolocationValue:forVariable:")]
        void SetCustomProfileGeolocationValue (TuneLocation value, string name);

        [Static, Export ("setCustomProfileVersionValue:forVariable:")]
        void SetCustomProfileVersionValue (string value, string name);

        [Static, Export ("getCustomProfileString:")]
        string GetCustomProfileString (string name);

        [Static, Export ("getCustomProfileDateTime:")]
        NSDate GetCustomProfileDateTime (string name);

        [Static, Export ("getCustomProfileNumber:")]
        NSNumber GetCustomProfileNumber (string name);

        [Static, Export ("getCustomProfileGeolocation:")]
        TuneLocation GetCustomProfileGeolocation (string name);

        [Static, Export ("clearCustomProfileVariable:")]
        void ClearCustomProfileVariable (string name);

        [Static, Export ("clearAllCustomProfileVariables")]
        void ClearAllCustomProfileVariables ();

        /* Power Hook API */

        [Static, Export ("registerHookWithId:friendlyName:defaultValue:")]
        void RegisterHookWithId (string hookId, string friendlyName, string defaultValue);

        [Static, Export ("getValueForHookById:")]
        string GetValueForHookById (string hookId);

        [Static, Export ("setValueForHookById:value:")]
        string SetValueForHookById (string hookId, string value);

        [Static, Export ("onPowerHooksChanged:")]
        void OnPowerHooksChanged (TuneCallback callback);

        /* Deep Action API */

        [Static, Export ("registerDeepActionWithId:friendlyName:data:andAction:")]
        void RegisterDeepActionWithId (string deepActionId, string friendlyName, NSDictionary data, DeepAction deepAction);

        [Static, Export ("executeDeepActionWithId:andData:")]
        void ExecuteDeepActionWithId (string deepActionId, NSDictionary data);

        /* Experiment API */

        [Static, Export ("getPowerHookVariableExperimentDetails")]
        NSDictionary GetPowerHookVariableExperimentDetails ();

        [Static, Export ("getInAppMessageExperimentDetails")]
        NSDictionary GetInAppMessageExperimentDetails ();


        /* Playlist API */

        [Static, Export ("onFirstPlaylistDownloaded:")]
        void OnFirstPlaylistDownloaded (TuneCallback callback);

        [Static, Export ("onFirstPlaylistDownloaded:withTimeout:")]
        void OnFirstPlaylistDownloaded (TuneCallback callback, double timeout);

        // User in segment API

        [Static, Export ("isUserInSegmentId:")]
        bool IsUserInSegmentId (string segmentId);

        [Static, Export ("isUserInAnySegmentIds:")]
        bool IsUserInAnySegmentIds (string[] segmentIds);
    }

    [BaseType (typeof (NSObject))]
    [Model][Protocol]
    public interface TuneDelegate {

        [Export ("tuneDidSucceedWithData:")]
        void TuneDidSucceed (NSData data);

        [Export ("tuneDidFailWithError:")]
        void TuneDidFail (NSError error);

        [Export ("tuneEnqueuedActionWithReferenceId:")]
        void TuneEnqueuedAction (string referenceId);

        [Export ("tuneEnqueuedRequest:postData:")]
        void TuneEnqueuedRequestWithPostData (string requestUrl, string postData);

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

        [Export ("addTag:withStringValue:")]
        void AddTag (string name, string value);

        [Export ("addTag:withStringValue:hashed:")]
        void AddTag (string name, string value, bool shouldHash);

        [Export ("addTag:withBooleanValue:")]
        void AddTagBoolean (string name, NSNumber value);

        [Export ("addTag:withDateTimeValue:")]
        void AddTag (string name, NSDate value);

        [Export ("addTag:withNumberValue:")]
        void AddTagNumber (string name, NSNumber value);

        [Export ("addTag:withGeolocationValue:")]
        void AddTag (string name, TuneLocation value);

        [Export ("addTag:withVersionValue:")]
        void AddTagVersion (string name, string value);

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

        [Export ("addTag:withStringValue:")]
        void AddTag (string name, string value);

        [Export ("addTag:withStringValue:hashed:")]
        void AddTag (string name, string value, bool shouldHash);

        [Export ("addTag:withBooleanValue:")]
        void AddTagBoolean (string name, NSNumber value);

        [Export ("addTag:withDateTimeValue:")]
        void AddTag (string name, NSDate value);

        [Export ("addTag:withNumberValue:")]
        void AddTagNumber (string name, NSNumber value);

        [Export ("addTag:withGeolocationValue:")]
        void AddTag (string name, TuneLocation value);

        [Export ("addTag:withVersionValue:")]
        void AddTagVersion (string name, string value);

        [Static, Export ("eventWithName:")]
        TuneEvent EventWithName (string name);

        [Static, Export ("eventWithId:")]
        TuneEvent EventWithId (int eventId);
    }

    [BaseType (typeof (NSObject))]
    [Protocol]
    public interface TuneLocation {
        [Export ("altitude")]
        NSNumber Altitude { get; set; }

        [Export ("latitude")]
        NSNumber Latitude { get; set; }

        [Export ("longitude")]
        NSNumber Longitude { get; set; }
    }
}
