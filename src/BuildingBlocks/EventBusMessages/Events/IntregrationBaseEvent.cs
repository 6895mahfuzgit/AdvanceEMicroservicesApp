using System;

namespace EventBusMessages.Events
{
    public class IntregrationBaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public IntregrationBaseEvent()
        {
            Id = new Guid();
            CreationDate = DateTime.UtcNow;
        }

        public IntregrationBaseEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }

    }
}
