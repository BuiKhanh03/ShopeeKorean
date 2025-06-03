using Microsoft.Extensions.Options;
using MimeKit;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.ConfigurationModels;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects;

using MailKit.Net.Smtp;
using MailKit.Security;
using ShopeeKorean.Service.Utilities;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Service
{
    public class MailService : IMailService
    {
        public readonly IRepositoryManager _repoManager;
        public readonly MailConfiguration _mail;
        private readonly ILoggerManager _loggerManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IOptions<JwtConfiguration> _configuration;

        public const string ConfirmEmail = "Confirm your email";
        public MailService(ILoggerManager loggerManager, IOptions<MailConfiguration> mailConfiguration, IRepositoryManager repositoryManager)
        {
            _loggerManager = loggerManager;
            _repoManager = repositoryManager;
            _mail = mailConfiguration.Value;
        }
        public async Task<bool> SendMail(MailData Mail_Data)
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(_mail.Name, _mail.EmailId);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(string.Empty, Mail_Data.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = Mail_Data.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = Mail_Data.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                await MailClient.ConnectAsync(_mail.Host, (int)_mail.Port!, SecureSocketOptions.StartTls);
                await MailClient.AuthenticateAsync(_mail.EmailId, _mail.Password);
                await MailClient.SendAsync(email_Message);
                await MailClient.DisconnectAsync(true);
                MailClient.Dispose();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendConfirmEmail(string ToEmail, string url)
        {
            MailData mailData = new MailData()
            {
                EmailSubject = ConfirmEmail,
                EmailBody = MailHelper.ConfirmEmailTemplate(url),
                EmailToId = ToEmail,
            };
            return await SendMail(mailData);
        }
    }
}
