using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using TwilioVoice;
using AndroidX.Core.App;
using Android;
using Android.Content.PM;
using Android.Widget;
using AndroidX.Core.Content;

namespace Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        int REQUEST_RECORD_AUDIO = 123;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            if (!CheckPermissionGranted(Manifest.Permission.RecordAudio))
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RecordAudio }, REQUEST_RECORD_AUDIO);
            }
            else
            {
                TestTwilioBinding();
            }
        }

        public bool CheckPermissionGranted(string Permissions)
        {
            // Check if the permission is already available.
            if (ActivityCompat.CheckSelfPermission(this, Permissions) != Permission.Granted)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_RECORD_AUDIO)
            {
                if (grantResults.Length <= 0)
                {
                    // If user interaction was interrupted, the permission request is cancelled and you
                    // receive empty arrays.
                    Toast.MakeText(this, "In order to test the Twilio binding the Record Audio permission is required!", ToastLength.Long).Show();
                }
                else if (grantResults[0] == PermissionChecker.PermissionGranted)
                {
                    // Permission was granted.
                    TestTwilioBinding();
                }
                else
                {
                    // Permission denied.
                    Toast.MakeText(this, "In order to test the Twilio binding the Record Audio permission is required!", ToastLength.Long).Show();
                }
            }


            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void TestTwilioBinding()
        {
            Voice.LogLevel = LogLevel.All;

            var connectOptions = new ConnectOptions.Builder("token").Build();

            Voice.Connect(this, connectOptions, CallListener.Instance);

            Toast.MakeText(this, "Testing Twilio Binding!", ToastLength.Long).Show();
        }
    }
}
