using System;
using ObjCRuntime;

[assembly: LinkWith ("MobileAppTracker-3.14.1.a", LinkTarget.Simulator, SmartLink = true, ForceLoad = true, Frameworks="AdSupport, CoreTelephony, iAd, MobileCoreServices, StoreKit, SystemConfiguration")]
