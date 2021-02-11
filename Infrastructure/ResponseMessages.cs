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

        public CustomResponse CategoryNotFound
        {
            get { return _responsesManager.GetResponce("CategoryNotFound"); }
        }

        public CustomResponse CategoryHasRelatedRecords
        {
            get { return _responsesManager.GetResponce("CategoryHasRelatedRecords"); }
        }

        public CustomResponse CategoryDeletedSuccessfully
        {
            get { return _responsesManager.GetResponce("CategoryDeletedSuccessfully"); }
        }

        public CustomResponse CategoryUpdatedSuccessfully
        {
            get { return _responsesManager.GetResponce("CategoryUpdatedSuccessfully"); }
        }

        public CustomResponse ItemNameRequired
        {
            get { return _responsesManager.GetResponce("ItemNameRequired"); }
        }

        public CustomResponse ItemCategoryRequired
        {
            get { return _responsesManager.GetResponce("ItemCategoryRequired"); }
        }

        public CustomResponse ItemQuantityRequired
        {
            get { return _responsesManager.GetResponce("ItemQuantityRequired"); }
        }

        public CustomResponse ItemBuyPriceRequired
        {
            get { return _responsesManager.GetResponce("ItemBuyPriceRequired"); }
        }

        public CustomResponse ItemNotFound
        {
            get { return _responsesManager.GetResponce("ItemNotFound"); }
        }

        public CustomResponse ItemHasRelatedRecords
        {
            get { return _responsesManager.GetResponce("ItemHasRelatedRecords"); }
        }

        public CustomResponse ItemDeletedSuccessfully
        {
            get { return _responsesManager.GetResponce("ItemDeletedSuccessfully"); }
        }

        public CustomResponse ItemUpdatedSuccessfully
        {
            get { return _responsesManager.GetResponce("ItemUpdatedSuccessfully"); }
        }

        public CustomResponse GlobalInternalServerError()
        {
            return _responsesManager.GetResponce("InternalServerError");
        }

        public CustomResponse OrderNotFound
        {
            get { return _responsesManager.GetResponce("OrderNotFound"); }
        }
        public CustomResponse OrderHasRelatedRecords
        {
            get { return _responsesManager.GetResponce("OrderHasRelatedRecords"); }
        }

        public CustomResponse OrderDeletedSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderDeletedSuccessfully"); }
        }

        public CustomResponse OrderCancelledSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderCancelledSuccessfully"); }
        }

        public CustomResponse CategoryParentNotFound
        {
            get { return _responsesManager.GetResponce("CategoryParentNotFound"); }
        }

        public CustomResponse InvalidOperation
        {
            get { return _responsesManager.GetResponce("InvalidOperation"); }
        }

        public CustomResponse OrderOrderedSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderOrderedSuccessfully"); }
        }

        public CustomResponse OrderShippedSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderShippedSuccessfully"); }
        }

        public CustomResponse OrderDeliveredSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderDeliveredSuccessfully"); }
        }

        public CustomResponse InvalidQunatity
        {
            get { return _responsesManager.GetResponce("InvalidQunatity"); }
        }

        public CustomResponse OrderItemNotFound
        {
            get { return _responsesManager.GetResponce("OrderItemNotFound"); }
        }

        public CustomResponse InvalidOrderItemQuantity
        {
            get { return _responsesManager.GetResponce("InvalidOrderItemQuantity"); }
        }

        public CustomResponse OrderItemDeletedSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderItemDeletedSuccessfully"); }
        }

        public CustomResponse OrderItemQuantityUpdatedSuccessfully
        {
            get { return _responsesManager.GetResponce("OrderItemQuantityUpdatedSuccessfully"); }
        }
    }
}
