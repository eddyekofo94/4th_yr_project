using Google.Apis.Services;

namespace mlm_console
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