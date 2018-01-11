namespace BaseSolution.Core.Pages
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainViewModel;
        }
    }
}
