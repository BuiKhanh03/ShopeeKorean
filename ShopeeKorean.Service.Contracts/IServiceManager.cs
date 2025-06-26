namespace ShopeeKorean.Service.Contracts
{
    public interface IServiceManager
    {
        IMailService MailService { get; }
        IUserService UserService { get; }
        ICartService CartService { get; }
        IOrderService OrderService { get; }
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        ICartItemService CartItemService { get; }
        IOrderItemService OrderItemService { get; }
        ICloudinaryService CloudinaryService { get; }
        IProductSizeService ProductSizeService { get; }
        IProductImageService ProductImageService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
