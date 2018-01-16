using SunstateEquip.RentalQuotes.Core.Infrastructure.Services;

namespace SunstateEquip.RentalQuotes.Core.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public CartViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
