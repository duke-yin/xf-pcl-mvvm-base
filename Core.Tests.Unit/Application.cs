using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Moq;

namespace Core.Tests.Unit
{
	public class Application
	{
		private static Application _instance;

		private Application()
		{
			NavigationService = new Mock<INavigationService>();
			SimpleIoc.Default.Register<INavigationService>(() => NavigationService.Object);
		}

		public static Application Current
		{
			get
			{
				return _instance = _instance ?? new Application();
			}
		}

		public Mock<INavigationService> NavigationService { get; private set;}
	}
}