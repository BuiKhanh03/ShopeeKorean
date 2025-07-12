using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.Constant.Cart;
using ShopNoteeKorean.Shared.Constant.Product;
using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;

namespace ShopeeKorean.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public CartItemService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<CartItemForGetDto>> CreateCartItem(CartItemForCreationDto cartItemDto, Guid userId, bool trackChanges, string? include = null)
        {
            var productResultCheck = await this.GetAndCheckProduct(cartItemDto.ProductId, trackChanges);
            if (!productResultCheck.IsSuccess)
                return Result<CartItemForGetDto>.BadRequest(productResultCheck.Errors!);

            var cart = await _repositoryManager.CartRepository.GetCart(userId, trackChanges, include);

            var productEntity = productResultCheck.GetValue<Product>();

            var cartItemResultCheck = await this.GetAndCheckCartItemByProduct(cartItemDto.ProductId, true, null); 
            if (cartItemResultCheck.IsSuccess)
            {
                // Nếu sản phẩm đã có trong giỏ hàng, thì tăng số lượng và cập nhật
                var existingCartItem = cartItemResultCheck.GetValue<CartItem>();
                existingCartItem.Quantity += cartItemDto.Quantity;
                existingCartItem.UpdatedAt = DateTimeOffset.UtcNow;

                _repositoryManager.CartItemRepository.UpdateCartItem(existingCartItem);
                await _repositoryManager.SaveAsync();

                var updatedDto = _mapper.Map<CartItemForGetDto>(existingCartItem);
                return Result<CartItemForGetDto>.Ok(updatedDto);
            }

            // Nếu chưa có thì thêm mới
            var cartItemEntity = _mapper.Map<CartItem>(cartItemDto);
            cartItemEntity.CreatedAt = DateTimeOffset.UtcNow;
            cartItemEntity.CartId = cart!.Id;
            cartItemEntity.PriceAtTime = productEntity.Price;

            await _repositoryManager.CartItemRepository.CreateCartItem(cartItemEntity);
            await _repositoryManager.SaveAsync();

            var cartItemReturned = _mapper.Map<CartItemForGetDto>(cartItemEntity);
            return Result<CartItemForGetDto>.Ok(cartItemReturned);
        }


        public async Task<Result> UpdateCartItem(CartItemForUpdateDto cartItemDto, Guid cartItemId, bool trackChanges, string? include = null)
        {
            var cartItemResultCheck = await this.GetAndCheckCartItem(cartItemId, trackChanges, include);
            if (!cartItemResultCheck.IsSuccess) return Result.BadRequest(cartItemResultCheck.Errors!);
            var cartItemValue = cartItemResultCheck.GetValue<CartItem>();
            var cartItemEntity = _mapper.Map(cartItemDto, cartItemValue);
            cartItemEntity.UpdatedAt = DateTimeOffset.UtcNow;
            this._repositoryManager.CartItemRepository.UpdateCartItem(cartItemEntity);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        public async Task<Result<Product>> GetAndCheckProduct(Guid productId, bool trackChanges, string? include = null) { 
            var productResult = await _repositoryManager.ProductRepository.GetProduct(productId, trackChanges, include);
            if (productResult == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(productResult);
        }

        public async Task<Result<CartItem>> GetAndCheckCartItemByProduct(Guid productId, bool trackChanges, string? include = null)
        {
            var cartItem = await _repositoryManager.CartItemRepository.GetCartItemByProduct(productId, trackChanges, include);
            if (cartItem == null) return Result<CartItem>.BadRequest([CartErrors.GetCartItemNotFoundWithId(productId)]);
            return Result<CartItem>.Ok(cartItem);
        }

        public async Task<Result<CartItem>> GetAndCheckCartItem(Guid cartItemId, bool trackChanges, string? include = null)
        {
            var cartItem = await _repositoryManager.CartItemRepository.GetCartItem(cartItemId, trackChanges, include);
            if (cartItem == null) return Result<CartItem>.BadRequest([CartErrors.GetCartItemNotFoundWithId(cartItemId)]);
            return Result<CartItem>.Ok(cartItem);
        }

        public async Task<Result> DeleteCartItem(Guid cartItemId, bool trackChanges)
        {
             var cartItemResult = await this.GetAndCheckCartItem(cartItemId, trackChanges);
            if(!cartItemResult.IsSuccess) return Result.BadRequest(cartItemResult.Errors!);
            _repositoryManager.CartItemRepository.DeleteCartItem(cartItemResult.GetValue<CartItem>());
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }
    }
}
