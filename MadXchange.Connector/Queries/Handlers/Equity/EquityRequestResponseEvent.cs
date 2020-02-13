﻿using Convey.CQRS.Events;
using System;

namespace MadXchange.Connector.Handlers.Equity
{
    public class EquityRequestResponseEvent : IEvent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime TimeStamp { get; } = DateTime.UtcNow;
    }
}