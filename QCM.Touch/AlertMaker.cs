using System;
using QCM.Portable;
using MonoTouch.UIKit;

namespace QCM.Touch
{
	public class AlertMaker : IAlertMaker
	{
		public AlertMaker ()
		{
		}

		#region IAlertMaker implementation
		public void DisplayAlert (string title, string message)
		{
			var Alert = new UIAlertView (title, message, null, "OK");
			Alert.Show ();
		}
		#endregion
	}
}

