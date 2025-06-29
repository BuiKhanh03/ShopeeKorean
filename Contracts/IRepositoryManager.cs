﻿using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        ICartRepository CartRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductSizeRepository ProductSizeRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        Task SaveAsync();
    }
}
