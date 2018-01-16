using SunstateEquip.RentalQuotes.Core.ViewModel;
using Xamarin.Forms;

namespace SunstateEquip.RentalQuotes.Core.Pages
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