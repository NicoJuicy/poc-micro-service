﻿using SimpleCRM.Infrastructure.MessageBroker.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Application.Events.External.TagCreated
{
    public class TagCreated : BaseIntegrationEvent, IIntegrationEvent
    {

        public TagCreated(string tenantId, Guid tagId, Guid contactId) : base(tenantId)
        {
            TagId = tagId;
            ContactId = contactId;
        }

        public Guid ContactId { get;  }
        public Guid TagId { get;  }

    }
}
