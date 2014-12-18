using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using QCM.Portable;

namespace QCM.Touch
{
	public partial class QCM_TouchViewController : UIViewController
	{
		public QCM_TouchViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();



		}
			

		#endregion
	}
}

