using System.ComponentModel.DataAnnotations;

namespace ShopeeKorean.Shared.DataTransferObjects.ProductSize
{
    public record ProductSizeDtoForManipulation
    {
        [Required]
        public string Size { get; set; }
    }
}
