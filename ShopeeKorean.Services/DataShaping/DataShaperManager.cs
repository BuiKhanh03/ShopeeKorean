﻿using ShopeeKorean.Service.Contracts;
using GarageManagementAPI.Service.DataShaping;
using ShopeeKorean.Shared.DataTransferObjects.Category;
using ShopeeKorean.Shared.DataTransferObjects.Product;

namespace ShopeeKorean.Service.DataShapping
{
    public class DataShaperManager : IDataShaperManager
    {
        private readonly Lazy<IDataShaper<CategoryDto>> _categoryShaper;
        private readonly Lazy<IDataShaper<ProductDto>> _productShapper;

        public DataShaperManager()
        {
            _categoryShaper = new Lazy<IDataShaper<CategoryDto>>(() => new DataShaper<CategoryDto>(CategoryDto.PropertiesInfo));
            _productShapper = new Lazy<IDataShaper<ProductDto>>(() => new DataShaper<ProductDto>(ProductDto.PropertiesInfo));
        }
        //.Value là thuộc tính của Lazy<T>, nó sẽ kích hoạt việc khởi tạo đối tượng nếu đối tượng đó chưa được khởi tạo trước đó. Nếu đối tượng đã được khởi tạo, thuộc tính .Value sẽ trả về đối tượng đó. 
        public IDataShaper<CategoryDto> Category => _categoryShaper.Value;
        public IDataShaper<ProductDto> Product => _productShapper.Value;
    }
}
