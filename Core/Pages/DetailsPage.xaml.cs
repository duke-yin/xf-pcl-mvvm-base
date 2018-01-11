namespace BaseSolution.Core.Pages
{
    public partial class DetailsPage : BasePage
    {
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.DetailsViewModel;
        }
    }
}
