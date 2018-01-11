using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace BaseSolution.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Handle the current domain unhandled exception event
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // Handle the task scheduler unobserved task exception event
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            // Handle the process exit event
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new Core.App());

            return base.FinishedLaunching(app, options);
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