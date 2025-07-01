using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.Shipping;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service
{
    public class ShippingService : IShippingService
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public ShippingService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<ShippingDto>> CreateShipping(ShippingForCreationDto shippingForCreation)
        {
            var shippingEntity = _mapper.Map<Shipping>(shippingForCreation);
            await _repositoryManager.ShippingRepository.CreateShipping(shippingEntity);
            var shippingResult = _mapper.Map<ShippingDto>(shippingEntity);
            return Result<ShippingDto>.Ok(shippingResult); 
        }
    }
}
