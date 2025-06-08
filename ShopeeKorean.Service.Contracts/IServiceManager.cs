namespace ShopeeKorean.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IMailService MailService { get; }
        IUserService UserService { get; }
        ICloudinaryService CloudinaryService { get; }
        ICategoryService CategoryService { get; }

        IProductService ProductService { get; }
    }
}
