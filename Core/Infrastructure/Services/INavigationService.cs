using System;
using SunstateEquip.RentalQuotes.Core.Enums;
using Xamarin.Forms;

namespace SunstateEquip.RentalQuotes.Core.Infrastructure.Services
{
    public interface INavigationService
    {
        void Configure(AppPages pageKey, Type pageType);
        void Initialize(NavigationPage page);
        void GoBack();
        void NavigateTo(AppPages pageKey);
        void NavigateTo(AppPages pageKey, object parameter);
    }
}
