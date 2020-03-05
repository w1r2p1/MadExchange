﻿using MadXchange.Exchange.Contracts;
using MadXchange.Exchange.Contracts.XchangeData;
using MadXchange.Exchange.Domain.Models;
using MadXchange.Exchange.Domain.Types;
using MadXchange.Exchange.Infrastructure.Stores;
using Microsoft.Extensions.Logging;
using OpenTracing;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace MadXchange.Connector.Services
{
    public interface IAccountManager
    {
        void RegisterClients();
        
        void DeRegisterClients();

        void RegisterClients(params Guid[] accounts);
    }

    /// <summary>
    /// To:
    /// - signal the key-store to add or remove accounts
    /// - signal the SocketConnectionService which connections to open and close
    /// </summary>
    public class AccountManager : IAccountManager
    {
        private readonly IApiKeySetStore _apiKeySetRepository;
        private readonly ISocketConnectionService _socketConnectionService;
        private readonly ILogger _logger;

        public AccountManager(IApiKeySetStore apikeysetRepo, ISocketConnectionService socketConnectionService, ILoggerFactory logger)
        {
            _apiKeySetRepository = apikeysetRepo;
            _socketConnectionService = socketConnectionService;
            _logger = logger.CreateLogger<AccountManager>();
        }

        public void DeRegisterClients()
        {
            throw new NotImplementedException();
        }

        public void RegisterClients(params Guid[] accounts) 
        {
            
           
        }

        public void RegisterClients() 
        {        
            var keyset = _apiKeySetRepository.Get(Xchange.ByBit);
            _socketConnectionService.RegisterSocketClient(keyset.Id);            
            _socketConnectionService.RegisterPublicSocket(Xchange.ByBit, new (string, string)[] { ("OrderBook", "BTCUSD"), ("OrderBook", "ETHUSD") }, Guid.NewGuid());
            
        }
        
    }
}