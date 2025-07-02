using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;

namespace ShopeeKorean.Service
{
    public class PaymentRecordService : IPaymentRecordService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public PaymentRecordService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }
        public async Task<Result<PaymentRecordDto>> CreatePaymentRecord(PaymentRecordForCreationDto paymentRecordForCreationDto)
        {
            var paymentEntity = _mapper.Map<PaymentRecord>(paymentRecordForCreationDto);
            await _repositoryManager.PaymentRecordRepository.CreatePaymentRecord(paymentEntity);
            await _repositoryManager.SaveAsync();
            var paymentResult = _mapper.Map<PaymentRecordDto>(paymentEntity);
            return Result<PaymentRecordDto>.Ok(paymentResult);
        }
    }
}
