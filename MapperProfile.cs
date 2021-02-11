using AutoMapper;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.Queries.Category;
using ECommerce.Models.BusinessUseCases.Item;
using ECommerce.Models.Queries.Item;
using ECommerce.Models.BusinessUseCases.Category;
using ECommerce.Models.Queries.Order;
using ECommerce.Models.BusinessUseCases.Order;
using ECommerce.Models.BusinessUseCases.OrderItem;
using ECommerce.Models.Queries.OrderItem;

namespace ECommerce
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Category Mapper
            CreateMap<CategoryDto, CreateCategoryModel>().ReverseMap();
            CreateMap<CategoryDto, GetAllCategoryModel>().ReverseMap();
            CreateMap<CategoryDto, GetCategoryModel>().ReverseMap();

            //ItemMapper
            CreateMap<ItemDto, CreateItemModel>().ReverseMap();
            CreateMap<ItemDto, SearchItemModel>().ReverseMap();
            CreateMap<ItemDto, GetItemModel>().ReverseMap();

            //OrderMapper
            CreateMap<OrderDto, CreateOrderModel>().ReverseMap();
            CreateMap<OrderDto, SearchOrderModel>().ReverseMap();
            CreateMap<OrderDto, GetOrderModel>().ReverseMap();
            CreateMap<OrderReport, OrderReportModel>().ReverseMap();

            //OrderItemMapper
            CreateMap<OrderItemDto, CreateOrderItemModel>().ReverseMap();
            CreateMap<OrderItemDto, GetOrderItemModel>().ReverseMap();
            CreateMap<OrderItemReport, OrderItemReportModel>().ReverseMap();
        }
    }
}
