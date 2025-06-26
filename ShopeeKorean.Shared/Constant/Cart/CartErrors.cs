using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.Cart
{
    public class CartErrors
    {
        public const string CartItemNotFound = "The category with id {0} is not found";
        public static ErrorsResult GetCartItemNotFoundWithId(Guid cartItemId)
            => new () { Code = CartItemNotFound, Description = string.Format(CartItemNotFound, cartItemId) };
    }
}
