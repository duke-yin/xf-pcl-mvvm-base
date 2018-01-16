using SunstateEquip.RentalQuotes.Core.CustomControls;
using SunstateEquip.RentalQuotes.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace SunstateEquip.RentalQuotes.iOS.Renderers
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