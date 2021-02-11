using StoreakApiService.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.BusinessUseCases.Item
{
    public class CreateItemModel
    {
        [RequiredValue(ErrorMessage = "ItemNameRequired")]
        public string Name { get; set; }
        public string Description { get; set; }
        [RequiredId(ErrorMessage = "ItemCategoryRequired")]
        public Guid CategoryId { get; set; }
        [RequiredRange(0, Int32.MaxValue, ErrorMessage = "ItemQuantityRequired")]
        public int Quantity { get; set; }
        [RequiredValue(ErrorMessage = "ItemBuyPriceRequired")]
        public decimal BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public bool SellAvaialable { get; set; }
        public string Picture { get; set; }
        public decimal Ranking { get; set; }
        public string Note { get; set; }
    }
}
