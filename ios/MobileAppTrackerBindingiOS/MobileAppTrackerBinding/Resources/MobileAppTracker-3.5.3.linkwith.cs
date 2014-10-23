using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("MobileAppTracker-3.5.3.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, ForceLoad = true, Frameworks="AdSupport CoreTelephony iAd MobileCoreServices SystemConfiguration")]
