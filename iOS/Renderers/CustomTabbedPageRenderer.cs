using BaseSolution.Core.CustomControls;
using BaseSolution.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace BaseSolution.iOS.Renderers
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            //TabBar.BarTintColor = Color.FromHex("#007BC2").ToUIColor();  
        }
    }
}