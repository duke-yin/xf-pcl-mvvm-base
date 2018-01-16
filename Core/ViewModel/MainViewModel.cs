using System.Windows.Input;
using SunstateEquip.RentalQuotes.Core.Enums;
using SunstateEquip.RentalQuotes.Core.Infrastructure.Services;
using Xamarin.Forms;

namespace SunstateEquip.RentalQuotes.Core.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        private readonly INavigationService _navigationService;

        public ICommand NavigateCommand { get; private set; }


        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new Command(() => Navigate());
        }

        private void Navigate()
        {
            _navigationService.NavigateTo(AppPages.DetailsPage);
        }
    }
}