using BaseSolution.Core.Infrastructure.Services;

namespace BaseSolution.Core.ViewModel
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
