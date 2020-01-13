﻿using MadXchange.Common.Handlers;
using MadXchange.Exchange.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MadXchange.Exchange.Messages.Commands.Handlers
{
    public class SetLeverageHandler : ICommandHandler<SetLeverage>
    {
        private readonly IExchangeOrderServiceClient _orderServiceClient;
        private readonly ILogger _logger;
        public SetLeverageHandler() 
        {
        
        }
        public async Task HandleAsync(SetLeverage leverage) 
        {
        
        }
    }
}