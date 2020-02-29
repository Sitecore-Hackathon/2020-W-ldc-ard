namespace Hackathon.Boilerplate.Foundation.DependencyInjection.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.DependencyInjection;
    public class MvcControllerServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllers("Hackathon.Boilerplate.Feature.*");
            serviceCollection.AddClassesWithServiceAttribute("Hackathon.Boilerplate.Feature.*");
            serviceCollection.AddClassesWithServiceAttribute("Hackathon.Boilerplate.Foundation.*");
        }
    }
}