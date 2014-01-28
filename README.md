# MAT Xamarin Binding

The MobileAppTracking (MAT) Binding for Xamarin provides basic application install
and event tracking functionality.

To track installs, you must first integrate the Xamarin binding with your app.
You may also add and track additional events beyond an app install (such as purchases,
game levels, and any other user engagement).

This document outlines the MAT Xamarin binding integration.


## Integration

* Open your project in Xamarin Studio.
* In Solution view, right click on References and select "Edit References...". 
* In the "Edit References" dialog, select ".Net Assembly" tab and browse to the folder that contains the MAT binding dll.
* Add a reference to MAT dll for your target platform -- MobileAppTrackingBinding.dll for iOS project or MobileAppTrackingBindingAndroid.dll for Android.

You can now access the `MobileAppTracker` class by adding `using HasOffers;` directive to your class.

For a complete example, see the implementation in the `MainActivity.cs` file of the binding's test app folder.

### Use MAT binding in iOS project

The MAT methods can be accessed using the shared object MobileAppTracker.SharedManager.

    MobileAppTracker mat;

After receiving `FinishedLaunching` event in AppDelegate.cs, initialize the MAT tracker with the `InitTracker` function, passing in
your MAT Advertiser ID and MAT Conversion Key:

    mat = MobileAppTracker.SharedManager;
    mat.InitTracker ("<YOUR_MAT_ADVERTISER_ID>", "<YOUR_MAT_CONVERSION_KEY>");

### Use MAT binding in Android project

Create a MobileAppTracker object in MainActivity.cs file. 

    MobileAppTracker mat;

After receiving `OnCreate` event in MainActivity.cs, initialize MAT:

    mat = new MobileAppTracker (this, MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);

### Installs and Updates

As the success of attributing app events after the initial install is dependent upon first tracking that install, 
we require that the install is the first event tracked. To track install of your mobile app, use the `TrackInstall` 
method. If users have already installed your app prior to SDK implementation, then these users should be tracked as updates by calling `TrackUpdate`.

#### Track Installs

To track installs of your mobile app, use the `TrackInstall` method. `TrackInstall` counts an install only the first time it is called and is a no-op after the first call in the same app version.

    mat.TrackInstall();

The `TrackInstall` method automatically tracks updates of your app if the app version differs from the last app version it saw.

#### Handling Installs Prior to SDK Implementation - Track as Updates

What if your app already has thousands or millions of users prior to SDK implementation? What happens when these users update 
the app to the new version that contains the MAT SDK?

MAT provides you two ways to make sure that the existing users do not count towards new app installs.

1. Call SDK method `TrackUpdate` instead of `TrackInstall`.

If you are integrating MAT into an existing app where you have users you’ve seen before, you can track an update yourself with the `TrackUpdate` method.

    mat.TrackUpdate();

2. Import prior installs to the platform.

These methods are useful if you already have an app in the store and plan to add the MAT SDK in a new version. 
Learn how to [handle installs prior to SDK implementation here](http://support.mobileapptracking.com/entries/22621001-Handling-Installs-prior-to-SDK-implementation).

If the code used to differentiate installs versus app updates is not properly implemented, then you will notice 
a [spike of total installs](http://support.mobileapptracking.com/entries/22900598-Spike-of-Total-Installs-on-First-day-of-SDK) on the first day of the SDK implementation.


### Events

After the install has been tracked, the `TrackAction` method is intended to be used to track user actions such as reaching a 
certain level in a game or making an in-app purchase. The `TrackAction` method allows you to define the event name dynamically.

    TrackAction(eventName, isId, referenceId, revenue, currency)

where

    eventName = name of event to track
    isId = whether eventName is passing event name or event ID # from MAT
    referenceId = advertiser ref ID to associate with event
    revenue = revenue amount to associate with event as double
    currency = ISO 4217 currency code of revenue

You need to supply the "eventName" field with the appropriate value for the event; e.g. "registration". If the event does
not exist, it will be dynamically created in our site. You may pass a revenue value, currency code,
or whether you are using an event ID or event name, as optional fields.

#### Registration

If you have a registration process, it's recommended to track it by calling trackAction set to "registration".

    mat.TrackAction("registration", false, "some_username", 0, "USD");

You can find these events in the platform by viewing Reports > Event Logs. Then filter the report by the "registration" event.

While our platform always blocks the tracking of duplicate installs, by default it does not block duplicate event requests. 
However, a registration event may be an event that you only want tracked once per device/user. 
Please see [block duplicate requests setting for events](http://support.mobileapptracking.com/entries/22927312-Block-Duplicate-Request-Setting-for-Events) for further information.

#### Purchases

The best way to analyze the value of your publishers and marketing campaigns is to track revenue from in-app purchases.
By tracking in-app purchases for a user, the data can be correlated back to the install and analyzed on a cohort basis 
to determine revenue per install and lifetime value.

    mat.TrackAction("purchase", false, "", 0.99, "USD");

__Track In-App Purchases__
The basic way to track purchases is to track an event with a name of purchase and then define the revenue (sale amount) and currency code.

__Note__: Pass the revenue in as a Double and the currency of the amount if necessary.  Currency is set to "USD" by default.
See [Setting Currency Code](http://support.mobileapptracking.com/entries/23697946-Customize-SDK-Settings) for currencies we support.

You can find these events in platform by viewing Reports > Logs > Events. Then filter the report by the "purchase" event.

#### Opens

The SDK allows you to analyze user engagement by tracking unique opens. The SDK has built in functionality to only track one "open" event
per user on any given day to minimize footprint. All subsequent "open" events fired on the same day are ignored and will not show up on the platform.

    mat.TrackAction("open", false, "", 0, "USD");

You can find counts of Opens by viewing Reports > Mobile Apps. Include the parameter of Opens to see the aggregated count.
The platform does not provide logs of Opens. If you track Opens using a name other than "open" then these tracked events will
cost the same price as all other events to track.

#### Other Events

You can track other events in your app dynamically by calling `TrackAction`. The `TrackAction` method is intended for tracking
any user actions. This method allows you to define the event name.

To dynamically track an event, replace "eventName" with the name of the event you want to track. The tracking engine
will then look up the event by the name. If an event with the defined name doesn’t exist, the tracking engine will automatically
create an event for you with that name. An Event Name has to be alphanumeric.

You can find these events in platform by viewing Reports->Logs->Event Logs.

The max event limit per site is 100. Learn more about the [max limit of events](http://support.mobileapptracking.com/entries/22803093-Max-Event-Limit-per-Site).

While our platform always blocks the tracking of duplicate installs, by default it does not block duplicate event requests. 
However, there may be other types of events that you only want tracked once per device/user. Please see [block duplicate requests setting for events](http://support.mobileapptracking.com/entries/22927312-Block-Duplicate-Request-Setting-for-Events) for further information.


### Testing Plugin Integration with SDK

These pages contain instructions on how to test whether the SDKs were successfully implemented for the various platforms:

[Testing Android SDK Integration](http://support.mobileapptracking.com/entries/22541781-Testing-Android-SDK-integration)

[Testing iOS SDK Integration](http://support.mobileapptracking.com/entries/22561876-testing-ios-sdk-integration)


### Debug Mode and Duplicates

__Debugging__

When the Debug mode is enabled in the SDK, the server responds with debug information about the success or failure of the
tracking requests.

To enable the debug mode, call the `SetDebugMode` method with Boolean `true`:

    mat.SetDebugMode(true);

__Note__: For Android, debug mode log output can be found in LogCat under the tag "MobileAppTracker".

On Android, enabling the debug mode lets you see the event status and server response.

On iOS, in order to see the server response, you need to implement `MobileAppTrackerDelegate` callback methods. (iOS only)

    mat.Delegate = new MATDelegate();

and implement the `MobileAppTrackerDelegate` subclass:

    public class MATDelegate : MobileAppTrackerDelegate
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

__Allow Duplicates__

The platform rejects installs from devices it has seen before.  For testing purposes, you may want to bypass this behavior
and fire multiple installs from the same testing device.
 
There are two methods you can employ to do so: (1) calling the `SetAllowDuplicates` method, and (2) set up a test profile.

(1) Call the `SetAllowDuplicates` after initializing `MobileAppTracker`, with Boolean `true`:

    mat.SetAllowDuplicates(true);

(2) Set up a [test profile](http://support.mobileapptracking.com/entries/22541401-Test-Profiles). A Test Profile should be 
used when you want to allow duplicate installs and/or events from a device you are using from testing and don't want to 
implement `SetAllowDuplicates` in the code and instead allow duplicate requests from the platform.


**_The `SetDebugMode` and `SetAllowDuplicates` calls are meant for use only during debugging and testing. Please be sure to disable these for release builds._**


### Additional Resources

#### Custom Settings

The SDK supports several custom identifiers that you can use as alternate means to identify your installs or events.
Call these setters before calling the corresponding `TrackInstall` or `TrackAction` code.

__OpenUDID__ (iOS only)

This sets the OpenUDID of the device. Can be generated with the official implementation at [http://OpenUDID.org](http://OpenUDID.org).
Calling this will do nothing on Android apps.

    mat.SetOpenUDID("your_open_udid");

__TRUSTe ID__

If you are integrating with the TRUSTe SDK, you can pass in your TRUSTe ID with `SetTRUSTeId`, which populates the "TPID" field.

    mat.SetTrusteTPID("your_truste_id");

__User ID__

If you have a user ID of your own that you wish to track, pass it in as a string with `SetUserId`. This populates the "User ID"
field in our reporting, and also the postback variable `{user_id}`.

    mat.SetUserId("custom_user_id");

The SDK supports several custom identifiers that you can use as alternate means to identify your installs or events.
Please navigate to the [Custom SDK Settings](http://support.mobileapptracking.com/entries/23738686-Customize-SDK-Settings) page for more information.

#### Event Items

While an event is like your receipt for a purchase, the event items are the individual items you purchased.
Event items allow you to define multiple items for a single event. The `TrackAction` method can include this event item data.

The function for tracking event items looks like this:

    TrackActionWithItems(eventName, isId, items, referenceId, revenue, currency)

items is an array of "event items" that have the following format:

    ("item1", 0.99f, 1, 0.99f, "6", "7", "8", "9", "10");
    ("item2", 0.50f, 2, 1.0f);

Sample tracking code:
	
    MATEventItem item1 = MATEventItem.EventItemWithName("item1", 0.99f, 1, 0.99f, "6", "7", "8", "9", "10");
    MATEventItem item2 = MATEventItem.EventItemWithName("item2", 0.50f, 2, 1.0f);
    
    mat.TrackActionWithReceipt("eventReceipt", false, new MATEventItem[]{item1, item2}, "ref3", 132.6f, "RUB", 0, GetSampleiTunesIAPReceipt());