using BaseSolution.Core.Infrastructure.Services;

namespace BaseSolution.Core.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public DetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
