using SunstateEquip.RentalQuotes.Core.CustomControls;
using SunstateEquip.RentalQuotes.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace SunstateEquip.RentalQuotes.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null) return;
            this.Control.BackgroundImage = new UIKit.UIImage();
        }
    }
}