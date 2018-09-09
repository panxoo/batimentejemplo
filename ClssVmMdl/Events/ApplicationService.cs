using Prism.Events;

namespace ClssVmMdl.Events
{
    public sealed class ApplicationService
    {
        private ApplicationService() { }

        private static readonly ApplicationService _instance = new ApplicationService();

        public static ApplicationService Instance { get { return _instance; } }

        private IEventAggregator _eventAggregator;
        public IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new EventAggregator();

                return _eventAggregator;
            }
        }
    }
}
