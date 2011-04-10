using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Events
{
    public class EventAggregator : IEventPublisher
    {
        private readonly ISubject<object> subject = new Subject<object>();

        public IObservable<TEvent> GetEvent<TEvent>()
        {
            return this.subject.AsObservable().OfType<TEvent>();
        }

        public void Publish<TEvent>(TEvent sampleEvent)
        {
            this.subject.OnNext(sampleEvent);
        }
    }
}
