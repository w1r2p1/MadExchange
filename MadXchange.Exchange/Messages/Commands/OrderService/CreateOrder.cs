﻿using Convey.CQRS.Commands;
using MadXchange.Exchange.Contracts;
using MadXchange.Exchange.Domain.Types;
using MadXchange.Exchange.Types;
using System;
using System.Collections.Generic;

namespace MadXchange.Exchange.Messages.Commands.OrderService
{
    public class CreateOrder : ICommand
    {
        public Guid Id { get; }
        public Xchange Exchange { get; set; }
        public Guid AccountId { get; set; }
        public string Symbol { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public OrderType? OrderType { get; set; }
        public TimeInForce? TimeInForce { get; set; }
        public OrderSide? Side { get; set; }

        public DateTime TimeStamp { get; } = DateTime.UtcNow;
        public IEnumerable<ExecInst> Execs { get; internal set; }

        public CreateOrder(Guid id, Xchange exchange, Guid accountId, string symbol, decimal? price, decimal? amount, OrderType? type, TimeInForce? tif, OrderSide? side = null)
        {
            Id = id == default ? Guid.NewGuid() : id;
            Exchange = exchange;
            AccountId = accountId;
            Symbol = symbol;
            Price = price;
            Amount = amount;
            OrderType = type;
            TimeInForce = tif;
            Side = side;
        }

        public CreateOrder(Guid id, IOrderPostRequest request)
        {
            Id = id == default ? Guid.NewGuid() : id;
            Exchange = request.Exchange;
            AccountId = request.AccountId;
            Symbol = request.Symbol;
            Price = request.Price;
            Amount = request.Quantity;
            OrderType = request.OrdType;
            TimeInForce = request.TimeInForce;            
            Side = request.Side.Value;
            
        }

      
    }
}