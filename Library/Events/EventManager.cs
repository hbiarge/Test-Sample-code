namespace Library.Events
{
    public static class EventManager
    {
        private static IEventPublisher current;

        public static IEventPublisher Current
        {
            get
            {
                return current ?? (current = new EventAggregator());
            }
        }
    }
}