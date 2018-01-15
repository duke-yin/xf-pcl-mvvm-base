using GalaSoft.MvvmLight.Ioc;
using BaseSolution.Core.Enums;
using BaseSolution.Core.Pages;
using BaseSolution.Core.ViewModel;
using Xamarin.Forms;
using BaseSolution.Core.Infrastructure.Services;
using BaseSolution.Core.CustomControls;

namespace BaseSolution.Core
{
    public partial class App : Application
    {
        //ViewModelLocator object to handle ViewModels and bindings between them and Views (Pages):
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public App()
        {
            InitializeComponent();

            INavigationService navigationService;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigationService = new NavigationService();

                // Configure pages:
                navigationService.Configure(AppPages.MainPage, typeof(MainPage));
                navigationService.Configure(AppPages.DetailsPage, typeof(CartPage));
                navigationService.Configure(AppPages.MajorCategoriesPage, typeof(MajorCategoriesPage));


                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            else
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();




            var tabPage = new MainPage();

            // You have to also set MainPage property for the app:
            MainPage = tabPage;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}