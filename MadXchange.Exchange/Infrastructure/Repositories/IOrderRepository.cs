﻿using MadXchange.Common.Types;
using MadXchange.Exchange.Domain.Models;

namespace MadXchange.Exchange.Infrastructure.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}