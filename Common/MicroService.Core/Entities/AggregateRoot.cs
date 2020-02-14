﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Core.Entities
{
    public abstract class AggregateRoot
    {
        private readonly ISet<IDomainEvent> _events = new HashSet<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;
        public AggregateId Id { get; protected set; }
        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();
    }
}
