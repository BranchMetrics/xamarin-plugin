using System;
using ObjCRuntime;

[assembly: LinkWith ("MobileAppTracker-3.7.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, Frameworks="AdSupport CoreTelephony iAd MobileCoreServices SystemConfiguration")]