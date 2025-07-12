using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Service.Extensions;
using ShopeeKorean.Entities.ConfigurationModels;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;
using System.Net.Sockets;

namespace ShopeeKorean.Service
{
    public class VnPayService : IVnPayService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly VnPayConfiguration _vnPayConfiguration;
        private readonly IOptions<VnPayConfiguration> _configuration;
        private readonly IRepositoryManager _repository;

        public VnPayService(IMapper mapper, ILoggerManager loggerManager, IOptions<VnPayConfiguration> configuration, IRepositoryManager repository)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _configuration = configuration;
            _vnPayConfiguration = _configuration.Value;
            _repository = repository;
        }
        public string CreatePaymentUrl(VnPayForCreationDto model, HttpContext context)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_vnPayConfiguration.TimeZone);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibraryExtension();
            var urlCallBack = "http://192.168.1.4:32768/api/vnpay/payment-callback";

            pay.AddRequestData("vnp_Version", _vnPayConfiguration.Version);
            pay.AddRequestData("vnp_Command", _vnPayConfiguration.Command);
            pay.AddRequestData("vnp_TmnCode", _vnPayConfiguration.TmnCode);
            pay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _vnPayConfiguration.CurrCode);
            pay.AddRequestData("vnp_IpAddr", "127.0.0.1");
            pay.AddRequestData("vnp_BankCode", "NCB");
            pay.AddRequestData("vnp_Locale", _vnPayConfiguration.Locale);
            pay.AddRequestData("vnp_OrderInfo", $"{model.OrderDescription} {model.Amount} {model.PaymentIdR}");
            pay.AddRequestData("vnp_OrderType", model.OrderType);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_vnPayConfiguration.BaseUrl, _vnPayConfiguration.HashSecret);

            return paymentUrl;
        }

        public VnPayDto PaymentExecute(IQueryCollection collections)
        {
            var pay = new VnPayLibraryExtension();
            var response = pay.GetFullResponseData(collections, _vnPayConfiguration.HashSecret!);
            return response;
        }

       
    }
}
