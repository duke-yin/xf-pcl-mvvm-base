namespace SunstateEquip.RentalQuotes.Core.Pages
{
    public partial class SettingsPage : BasePage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.SettingsViewModel;
        }
    }
}
