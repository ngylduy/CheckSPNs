using CheckSPNs.Domain;
using CheckSPNs.Domain.Helpers;
using CheckSPNs.Service.EF.Abstract;
using MimeKit;

namespace CheckSPNs.Service.EF.Implementations
{
    public class EmailsService : IEmailsService
    {
        private readonly MailSettings _mailSettings;

        public EmailsService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task SendEmailAsync(CancellationToken cancellationToken, EmailRequest emailRequest)
        {
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_mailSettings.Provider, _mailSettings.Port, true);
                    client.Authenticate(_mailSettings.DefaultSender, _mailSettings.Password);

                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = emailRequest.Content
                    };

                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };

                    message.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.DefaultSender);
                    message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.DefaultSender));
                    message.To.Add(MailboxAddress.Parse(emailRequest.To));
                    message.Subject = emailRequest.Subject;

                    //if (emailRequest.AttachmentFilePaths.Length > 0)
                    //{
                    //    foreach (var path in emailRequest.AttachmentFilePaths)
                    //    {
                    //        Attachment attachment = new Attachment(path);

                    //        message.Attachments.Add(attachment);
                    //    }
                    //}

                    await client.SendAsync(message, cancellationToken);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
