using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure
{
    public class ResponseMessages : IResponseMessages
    {
        IResponsesManager _responsesManager;

        public ResponseMessages(IResponsesManager responsesManager)
        {
            _responsesManager = responsesManager;
        }

        public CustomResponse GlobalInternalServerError()
        {
            return _responsesManager.GetResponce("InternalServerError");
        }
    }
}
