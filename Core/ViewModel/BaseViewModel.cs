using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace SunstateEquip.RentalQuotes.Core.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        
        public async Task OnFirstTimeLoad()
        {
            try
            {
                await FirstLoad();
            }
            catch (Exception ex)
            {
                ErrorHandling(ex);
            }
        }

        internal async Task OnAppearing()
        {
            try
            {
                await Appearing();
            }
            catch (Exception ex)
            {
                ErrorHandling(ex);
            }
        }

        internal async Task OnDisappearing()
        {
            try
            {
                await Disappearing();
            }
            catch (Exception ex)
            {
                ErrorHandling(ex);
            }
        }


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal virtual async Task FirstLoad()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal virtual async Task Appearing()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal virtual async Task Disappearing()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }

        protected virtual void ErrorHandling(Exception ex)
        {
            // Custom error handling
            // ...

        }
    }
}