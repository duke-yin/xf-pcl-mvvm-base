using System;
namespace Core.Tests.Unit
{
	public class TestBaseClass
	{
		public Application RunningApplication
		{
			get;
			private set;
		}

		public TestBaseClass()
		{
			RunningApplication = Application.Current;	
		}
	}
}

