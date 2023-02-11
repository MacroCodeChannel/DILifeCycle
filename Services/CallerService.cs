using DILifeCycle.Interfaces;

namespace DILifeCycle.Services
{
    public class CallerService : ITransientService,IScopedService,ISingletonService
    {
        Guid currentGuid;
        public CallerService()
        {
            currentGuid = Guid.NewGuid();
        }

        public Guid GetCurrentGUID() 
        {
            return currentGuid;
        }
    }
}
