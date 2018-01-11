using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;

namespace Core.Tests.Unit
{
	[TestFixture]
	public class MainViewModelTests: TestBaseClass
	{
		[SetUp]
		public void Init()
		{
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //init method is called for every method we need to reset the IoC
            SimpleIoc.Default.Reset();

		}

        [Test]
        public void Test1()
        {
            Assert.IsEmpty(string.Empty);
        }
	}
}
