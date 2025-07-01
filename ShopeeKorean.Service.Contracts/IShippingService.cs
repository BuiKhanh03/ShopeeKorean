using ShopeeKorean.Shared.DataTransferObjects.Shipping;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IShippingService
    {
        public Task<Result<ShippingDto>> CreateShipping(ShippingForCreationDto shippingForCreation);
    }
}
