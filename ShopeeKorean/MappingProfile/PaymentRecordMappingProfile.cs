using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;

namespace ShopeeKorean.Application.MappingProfile
{
    public class PaymentRecordMappingProfile : Profile
    {
        public PaymentRecordMappingProfile()
        {
            CreateMap<PaymentRecord, PaymentRecordDto>();
            CreateMap<PaymentRecordForCreationDto, PaymentRecord>();
            CreateMap<PaymentRecord, VnPayDto>();
        }
    }
}
