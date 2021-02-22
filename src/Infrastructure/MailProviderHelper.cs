using Core;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MailProviderHelper : IMailProviderHelper
	{
		private readonly ISmtpClient _smtpClient;

		private readonly string SenderName, SenderEmail, SmtpHost, SmtpUserName, SmtpPassword;
		private readonly int SmtpPort;
		private readonly bool UseSsl;

		public MailProviderHelper(ISmtpClient smtpClient, string senderName, string senderEmail, string smtpHost, int smtpPort, string smtpUserName, string smtpPassword, bool useSsl = false)
		{
			_smtpClient = smtpClient;

			SenderName = senderName;
			SenderEmail = senderEmail;
			SmtpHost = smtpHost;
			SmtpPort = smtpPort;
			SmtpUserName = smtpUserName;
			SmtpPassword = smtpPassword;
			UseSsl = useSsl;
		}

		public async Task SendAsync(Mail mail)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress(SenderName, SenderEmail));
			message.To.Add(new MailboxAddress(mail.ToName, mail.To));
			message.Subject = mail.Subject;

			message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = mail.Body
			};

			using (var client = _smtpClient)
			{
				client.Connect(SmtpHost, SmtpPort, UseSsl);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate(SmtpUserName, SmtpPassword);

				await client.SendAsync(message);
				client.Disconnect(true);
			}
		}
	}
}
