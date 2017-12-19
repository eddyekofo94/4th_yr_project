using Google.Apis.Services;

namespace mlm
{
    internal class ComputeService
    {
        private BaseClientService.Initializer initializer;

        public ComputeService(BaseClientService.Initializer initializer)
        {
            this.initializer = initializer;
        }
    }
}