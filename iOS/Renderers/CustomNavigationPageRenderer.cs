using BaseSolution.Core.CustomControls;
using BaseSolution.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]

namespace BaseSolution.iOS.Renderers
{
    public class CustomNavigationPageRenderer: NavigationRenderer
    {
        public CustomNavigationPageRenderer() : base()
        {
            // Remove the bottom black line
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
        }
    }
}