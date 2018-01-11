using BaseSolution.Core.ViewModel;
using Xamarin.Forms;

namespace BaseSolution.Core.Pages
{
    public partial class BasePage : ContentPage
    {

        public BaseViewModel ViewModel => (BaseViewModel)BindingContext;

        public BasePage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ViewModel.OnDisappearing();
        }
    }
}