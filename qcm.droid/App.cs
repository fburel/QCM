using System;
using Android.App;
using QCM.Portable;
using Android.Runtime;

namespace qcm.droid
{
	[Application]
	public class App : Application
	{
		void registerService ()
		{
			var locator = ServiceLocator.Instance;
			locator.Add<IAlertMaker>(new AlertMaker (this));
		}

		public App (IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
		{

		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			registerService ();

		}
	}
}

