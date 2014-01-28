// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MATTest
{
	[Register ("MATTestViewController")]
	partial class MATTestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnAction { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnActionWithItems { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnActionWithReceipt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnAllowDup { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnDebug { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnInstall { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPrintSDKParams { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSetterMethods { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnStart { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnUpdate { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (btnDebug != null) {
				btnDebug.Dispose ();
				btnDebug = null;
			}

			if (btnAllowDup != null) {
				btnAllowDup.Dispose ();
				btnAllowDup = null;
			}

			if (btnPrintSDKParams != null) {
				btnPrintSDKParams.Dispose ();
				btnPrintSDKParams = null;
			}

			if (btnInstall != null) {
				btnInstall.Dispose ();
				btnInstall = null;
			}

			if (btnUpdate != null) {
				btnUpdate.Dispose ();
				btnUpdate = null;
			}

			if (btnAction != null) {
				btnAction.Dispose ();
				btnAction = null;
			}

			if (btnActionWithItems != null) {
				btnActionWithItems.Dispose ();
				btnActionWithItems = null;
			}

			if (btnActionWithReceipt != null) {
				btnActionWithReceipt.Dispose ();
				btnActionWithReceipt = null;
			}

			if (btnSetterMethods != null) {
				btnSetterMethods.Dispose ();
				btnSetterMethods = null;
			}
		}
	}
}
