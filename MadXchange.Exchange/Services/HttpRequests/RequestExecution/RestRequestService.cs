﻿using MadXchange.Exchange.Contracts.Http;
using MadXchange.Exchange.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MadXchange.Exchange.Services.HttpRequests.RequestExecution
{
    public interface IRestRequestService
    {
        //private functions: meh..
        Task<WebResponseDto> SendRequestObjectAsync(Guid accountId, XchangeRequestObject routeObject, CancellationToken token);

        //public functions: easy, peasy, we dont have to fudge with the header
        Task<WebResponseDto> SendGetAsync(string url);
    }

    public class RestRequestService : IRestRequestService
    {
        private readonly IRequestAccessService _requestAccessService;
        private readonly IRequestExecutionService _requestExecutionService;
        private readonly ISignRequests _signRequestService;

        public RestRequestService(IRequestExecutionService requestExecutionService, IRequestAccessService accessService, ISignRequests signRequestService)
        {
            _requestAccessService = accessService;
            _requestExecutionService = requestExecutionService;
            _signRequestService = signRequestService;
        }

        public async Task<WebResponseDto> SendRequestObjectAsync(Guid accountId, XchangeRequestObject routeObject, CancellationToken token = default)
        {
            //var permit = await _requestAccessService.RequestAccess(accountId, token);
            ////if request was cancelled by CancellationToken, request gets aborted before execution, no permission to send then, otherwise it will wait until access is granted
            //if (!permit) return default;
            _signRequestService.SignRequestObject(accountId, ref routeObject);
            var response = await _requestExecutionService.SendRequestObjectAsync(routeObject).ConfigureAwait(false);
            //_requestAccessService.UpdateAccountRequestCache(accountId, response);
            return response;
        }

        /// <summary>
        /// public functions dont need any further processing => inline !
        /// </summary>
        /// <param name="url"></param>
        /// <returns>WebResponse</returns>
        public async Task<WebResponseDto> SendGetAsync(string url) => await _requestExecutionService.SendGetAsync(url).ConfigureAwait(false);
    }
}