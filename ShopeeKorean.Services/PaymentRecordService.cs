using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.Constant.PaymentRecord;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;
using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.Constant.Order;
using ShopeeKorean.Shared.Extension;

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

        public async Task<Result<PaymentRecordDto>> SaveVnPayPament(VnPayDto vnPayDto)
        {
            if (!vnPayDto.IsSuccess || vnPayDto.VnPayResponseCode != "00")
                return Result<PaymentRecordDto>.BadRequest([PaymentRecordErrors.GetVnPayNotSuccess("Thanh toán không thành công hoặc chữ ký không hợp lệ.")]);
            var orderResult = await this.GetAndCheckOrder(vnPayDto.OrderId);
            var paymentResult = await this.GetAndCheckPaymentByOrder(vnPayDto.OrderId);
            if (!paymentResult.IsSuccess) return Result<PaymentRecordDto>.BadRequest(paymentResult.Errors!);
            if (!orderResult.IsSuccess) return Result<PaymentRecordDto>.BadRequest(orderResult.Errors!);

            var paymentRecordEntity = paymentResult.GetValue<PaymentRecord>();
            var paymentRecordDto = _mapper.Map(vnPayDto, paymentResult);
            paymentRecordEntity.PaymentRecordStatus = Shared.Enums.Status.PaymentRecordStatus.Completed;
            _repositoryManager.PaymentRecordRepository.UpdatePaymentRecord(paymentRecordEntity);
            await _repositoryManager.SaveAsync();
            var paymentRecordRetured = _mapper.Map<PaymentRecordDto>(paymentRecordDto);
            return Result<PaymentRecordDto>.Ok(paymentRecordRetured);
        }

        private async Task<Result<Order>> GetAndCheckOrder(Guid orderId)
        {
            var order = await _repositoryManager.OrderRepository.GetOrder(orderId, false, null);
            if (order == null) return Result<Order>.BadRequest([OrderErrors.GetOrderNotFound(orderId)]);
            return Result<Order>.Ok(order);
        }

        private async Task<Result<PaymentRecord>> GetAndCheckPaymentByOrder(Guid orderId)
        {
            var paymentRecord = await _repositoryManager.PaymentRecordRepository.GetPaymentRecordByOrder(orderId, true, null);
            if (paymentRecord == null) return Result<PaymentRecord>.BadRequest([PaymentRecordErrors.GetPaymentRecordByOrderNotFound(orderId)]);
            return Result<PaymentRecord>.Ok(paymentRecord);
        }
    }
}
