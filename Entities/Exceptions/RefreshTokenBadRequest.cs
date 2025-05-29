namespace ShopeeKorean.Application.Extensions.Exceptions
{
    public sealed class RefreshTokenBadRequest : Exception
    {
        public RefreshTokenBadRequest() : base("\"Invalid client request. The tokenDto has some invalid values.")
        {

        }
    }
}
