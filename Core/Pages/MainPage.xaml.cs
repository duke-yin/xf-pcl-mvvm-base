using BaseSolution.Core.CustomControls;
using Xamarin.Forms;

namespace BaseSolution.Core.Pages
{
    public partial class MainPage : CustomTabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainViewModel;

            var majorCategoriesPage = new CustomNavigationPage(new MajorCategoriesPage());
            majorCategoriesPage.BarBackgroundColor = Color.FromHex("#007BC2");
            majorCategoriesPage.BarTextColor = Color.White;
            majorCategoriesPage.Title = "RENTAL EQUIPMENT";
            majorCategoriesPage.Icon = "ic_rental_equipment.png";

            var cartPage = new CustomNavigationPage(new CartPage());
            cartPage.BarBackgroundColor = Color.FromHex("#007BC2");
            cartPage.BarTextColor = Color.White;
            cartPage.Title = "CART";
            cartPage.Icon = "ic_shopping_cart.png";

            var settingsPage = new CustomNavigationPage(new SettingsPage());
            settingsPage.BarBackgroundColor = Color.FromHex("#007BC2");
            settingsPage.BarTextColor = Color.White;
            settingsPage.Title = "SETTINGS";
            settingsPage.Icon = "ic_settings.png";


            Children.Add(majorCategoriesPage);
            Children.Add(cartPage);
            Children.Add(settingsPage);
        }
    }
}