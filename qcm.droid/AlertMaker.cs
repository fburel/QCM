using System;
using QCM.Portable;
using Android.Content;
using Android.App;

namespace qcm.droid
{
	public class AlertMaker : IAlertMaker
	{
	
		Context context;

		public AlertMaker (Context c)
		{
			context = c;
		}


		#region IAlertMaker implementation
		public void DisplayAlert (string title, string message)
		{
			var alert = new AlertDialog.Builder (context)
				.SetTitle (title)
				.SetMessage (message)
				.SetCancelable (true)
				.SetNegativeButton ("OK", delegate {

				})
				.Create ();
			alert.Show ();
		}
		#endregion
	}
}

