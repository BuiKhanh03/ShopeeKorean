using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.Cart;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public CartService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<CartDto>> GetCart(Guid userId, bool trackChanges, string? include = default)
        {
            var cart = await _repositoryManager.CartRepository.GetCart(userId, trackChanges, include);
            var cartDto = _mapper.Map<CartDto>(cart);
            return Result<CartDto>.Ok(cartDto);
        }
    }
}
