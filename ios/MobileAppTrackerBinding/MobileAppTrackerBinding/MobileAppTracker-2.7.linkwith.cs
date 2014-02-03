using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("MobileAppTracker-2.7.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks="CoreTelephony MobileCoreServices SystemConfiguration", WeakFrameworks="AdSupport")]
