using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Order;

namespace ShopeeKorean.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public OrderService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public Task<Result<OrderDto>> CreateOrder(OrderForCreationDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<OrderDto>> GetOrder(Guid orderId, bool trackChanges, string? isInclude = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<OrderDto>>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateOrder(OrderForUpdateDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
