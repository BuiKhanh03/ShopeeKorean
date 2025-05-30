using ShopeeKorean.Shared.DataTransferObjects;

namespace ShopeeKorean.Service.Contracts
{
    public interface IMailService
    {
        Task<bool> SendConfirmEmailEmail(string ToEmail, string url);
        Task<bool> SendMail(MailData Mail_Data);
    }
}
