using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("MobileAppTracker.a", LinkTarget.Simulator | LinkTarget.ArmV7s | LinkTarget.ArmV7, ForceLoad = true, Frameworks="CoreTelephony MobileCoreServices SystemConfiguration", WeakFrameworks="AdSupport")]
