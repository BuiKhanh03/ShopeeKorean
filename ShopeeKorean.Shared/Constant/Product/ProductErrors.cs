using ShopeeKorean.Shared.ErrorModel;

namespace ShopNoteeKorean.Shared.Constant.Product
{
    public class ProductErrors
    {
        #region Error message
        private const string ProductNotFound = "Product not found with id {0}";

        private const string Product_CategoryNotFound = "Category not found with id {0}";
        private const string Product_UerNotFound = "User not found with id {0}";

        private const string Product_ImageNotFound = "Product Image not found with id {0}";
        private const string Product_SizeNotFound = "Product Size not found with id {0}";
        #endregion
        #region Static Method
        public static ErrorsResult GetProductNotFound(Guid productId)
            => new () { Code = ProductNotFound, Description = string.Format(ProductNotFound, productId) };

        public static ErrorsResult GetProduct_CategoryNotFound(Guid categoryId)
            => new() { Code = Product_CategoryNotFound, Description = string.Format(Product_CategoryNotFound, categoryId) };

        public static ErrorsResult GetProduct_UserNotFound(Guid sellerId)
            => new () { Code = Product_UerNotFound, Description = string.Format(Product_UerNotFound, sellerId) };

        public static ErrorsResult GetProduct_ImageNotFound(Guid productImageId)
            => new () { Code = Product_ImageNotFound, Description = string.Format(Product_ImageNotFound, productImageId) };

        public static ErrorsResult GetProduct_ImageNotFoundImageId(string imageId)
            => new() { Code = Product_ImageNotFound, Description = string.Format(Product_ImageNotFound, imageId) };

        public static ErrorsResult GetProduct_SizeNotFound(Guid productSizeId)
            => new() { Code = Product_SizeNotFound, Description = string.Format(Product_SizeNotFound, productSizeId) };
        #endregion
    }
}
