using System.ComponentModel.DataAnnotations;

namespace ShopeeKorean.Shared.DataTransferObjects.ProductSize
{
    public record ProductSizeDtoForCreation
    {
        public string Size { get; set; }
    }
}
