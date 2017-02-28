using ObjCRuntime;

[assembly: LinkWith ("Tune-4.12.2.a", SmartLink = true, ForceLoad = false, Frameworks="AdSupport, CoreSpotlight, CoreTelephony, iAd, MobileCoreServices, QuartzCore, Security, StoreKit, SystemConfiguration", LinkerFlags="-ObjC -lz")]
