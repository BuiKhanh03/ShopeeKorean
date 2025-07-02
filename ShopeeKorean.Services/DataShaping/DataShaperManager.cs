using ShopeeKorean.Service.Contracts;
using GarageManagementAPI.Service.DataShaping;
using ShopeeKorean.Shared.DataTransferObjects.Order;
using ShopeeKorean.Shared.DataTransferObjects.Product;
using ShopeeKorean.Shared.DataTransferObjects.Category;

namespace ShopeeKorean.Service.DataShapping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<CategoryDto>> _categoryShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShapper;
        private readonly Lazy<IDataShaper<OrderDto>> _orderShapper;

        public DataShaperManager()
        {
            _categoryShaper = new Lazy<IDataShaper<CategoryDto>>(() => new DataShaper<CategoryDto>(CategoryDto.PropertiesInfo));
            _productShapper = new Lazy<IDataShaper<ProductDto>>(() => new DataShaper<ProductDto>(ProductDto.PropertiesInfo));
            _orderShapper = new Lazy<IDataShaper<OrderDto>>(() => new DataShaper<OrderDto>(OrderDto.PropertiesInfo));
        }
        //.Value là thuộc tính của Lazy<T>, nó sẽ kích hoạt việc khởi tạo đối tượng nếu đối tượng đó chưa được khởi tạo trước đó. Nếu đối tượng đã được khởi tạo, thuộc tính .Value sẽ trả về đối tượng đó. 
        public IDataShaper<CategoryDto> Category => _categoryShaper.Value;
        public IDataShaper<ProductDto> Product => _productShapper.Value;
        public IDataShaper<OrderDto> Order => _orderShapper.Value;  
    }
}
