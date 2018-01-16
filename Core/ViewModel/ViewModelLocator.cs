using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace SunstateEquip.RentalQuotes.Core.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<BaseViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CartViewModel>();
            SimpleIoc.Default.Register<MajorCategoriesViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        public BaseViewModel BaseViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BaseViewModel>();
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CartViewModel DetailsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartViewModel>();
            }
        }

        public MajorCategoriesViewModel MajorCategoriesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MajorCategoriesViewModel>();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}