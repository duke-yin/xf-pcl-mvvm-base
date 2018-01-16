namespace SunstateEquip.RentalQuotes.Core.Pages
{
    public partial class CartPage : BasePage
    {
        public CartPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.DetailsViewModel;
        }
    }
}
