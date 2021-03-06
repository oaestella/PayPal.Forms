﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;

namespace PayPal.Forms.Test.PCL.Droid
{
	[Activity (Label = "PayPal.Forms.Test.PCL.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			Forms.CrossPayPalManager.Init (
				new PayPalConfiguration (
					PayPalEnvironment.NoNetwork,
					"YOUR ID STRING"
				){
					AcceptCreditCards = true,
					MerchantName = "Test Store",
					MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
					MerchantUserAgreementUri = "https://www.example.com/legal"
				}
			);

			LoadApplication (new App ());
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			PayPalManagerImplementation.Manager.OnActivityResult (requestCode, resultCode, data);
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			PayPalManagerImplementation.Manager.Destroy ();
		}
	}
}

