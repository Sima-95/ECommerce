using System;
using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using System.Threading.Tasks;
using ECommerce.Models.Queries.Item;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace ECommerce.Application.Queries.Item
{
    public class ItemQueries
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public ItemQueries(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            ItemDto item = await _unitOfWork.ItemRepository.FindAsync(id);
            if (item == null)
                return _responsMessages.ItemNotFound;

            GetItemModel model = _mapper.Map<GetItemModel>(item);

            return new OkResponse(model);
        }

        public async Task<CustomResponse> Search(PagingParams pagingParams,string filter)
        {
            var result = await _unitOfWork.ItemRepository
                                    .GetAll()
                                    .Where(Helpers.FilterHelper.filterJsonToString(filter))
                                    .GetPagedAsync<ItemDto, SearchItemModel>(pagingParams, _mapper);
            return new OkResponse(result);
        }
    }
}
