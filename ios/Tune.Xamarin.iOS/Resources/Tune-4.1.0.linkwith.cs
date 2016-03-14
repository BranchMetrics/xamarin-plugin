using ObjCRuntime;

[assembly: LinkWith ("Tune-4.1.0.a", SmartLink = true, ForceLoad = false, Frameworks="AdSupport, CoreTelephony, iAd, MobileCoreServices, QuartzCore, Security, StoreKit, SystemConfiguration", LinkerFlags="-ObjC -lz")]
