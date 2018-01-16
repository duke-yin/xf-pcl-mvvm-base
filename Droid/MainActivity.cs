using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using RentalQuotes.Droid;
using SunstateEquip.RentalQuotes.Core;

namespace SunstateEquip.RentalQuotes.Droid
{
    [Activity(Label = "Rental Quotes", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            // Handle the current domain unhandled exception event
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // Handle the task scheduler unobserved task exception event
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            // Handle the process exit event
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            // Handle additional AndroidEnvironment unhandled exceptions
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            // Error Handling
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            // Error Handling
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Error Handling
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Error Handling
        }
    }
}
