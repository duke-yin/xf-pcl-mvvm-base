namespace BaseSolution.Infrastructure
{
    public interface IApplicationService
    {
        string GetApplicationVersionNumber();
        string GetDeviceOS();
	}
}