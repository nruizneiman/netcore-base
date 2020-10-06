using Core;
using MailKit.Net.Smtp;
using MimeKit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests
{
    public class MailProviderHelperTests
    {
        private readonly string SmtpHost, SmtpUserName, SmtpPassword;
        private readonly int SmtpPort;
        private readonly bool UseSsl;
        private readonly string From;
        private readonly string FromName;
        private readonly Mock<ISmtpClient> _smtpClientMock;

        public MailProviderHelperTests()
        {
            SmtpHost = "127.0.0.1";
            SmtpUserName = "admin";
            SmtpPassword = "1234";
            SmtpPort = 80;
            UseSsl = false;

            From = "info@foo.org.ar";
            FromName = "Foo Bar";

            _smtpClientMock = new Mock<ISmtpClient>();
        }

        [Fact]
        public async Task ShouldConnectToTheClientAsync()
        {
            var mailProvider = new MailProviderHelper(_smtpClientMock.Object, FromName, From, SmtpHost, SmtpPort, SmtpUserName, SmtpPassword, UseSsl);

            _smtpClientMock.Setup(x => x.Connect(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>(), CancellationToken.None)).Verifiable();

            await mailProvider.SendAsync(CreateNewMailObject());

            _smtpClientMock.Verify(x => x.Connect(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task ShouldCallAuthenticateAsync()
        {
            var mailProvider = new MailProviderHelper(_smtpClientMock.Object, FromName, From, SmtpHost, SmtpPort, SmtpUserName, SmtpPassword, UseSsl);

            _smtpClientMock.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None)).Verifiable();

            await mailProvider.SendAsync(CreateNewMailObject());

            _smtpClientMock.Verify(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task ShouldCallSendAsync()
        {
            var mailProvider = new MailProviderHelper(_smtpClientMock.Object, FromName, From, SmtpHost, SmtpPort, SmtpUserName, SmtpPassword, UseSsl);

            _smtpClientMock.Setup(x => x.SendAsync(It.IsAny<MimeMessage>(), CancellationToken.None, null)).Verifiable();

            await mailProvider.SendAsync(CreateNewMailObject());

            _smtpClientMock.Verify(x => x.SendAsync(It.IsAny<MimeMessage>(), CancellationToken.None, null), Times.Once);
        }

        [Fact]
        public async Task ShouldDisposeTheClientAsync()
        {
            var mailProvider = new MailProviderHelper(_smtpClientMock.Object, FromName, From, SmtpHost, SmtpPort, SmtpUserName, SmtpPassword, UseSsl);

            _smtpClientMock.Setup(x => x.Disconnect(It.IsAny<bool>(), CancellationToken.None)).Verifiable();

            await mailProvider.SendAsync(CreateNewMailObject());

            _smtpClientMock.Verify(x => x.Disconnect(It.IsAny<bool>(), CancellationToken.None), Times.Once);
        }

        #region Mocked Objects
        private Mail CreateNewMailObject()
        {
            return new Mail
            {
                To = "foo@bar.com",
                ToName = "Foo Bar",
                Subject = "Test",
                Body = "This is the body"
            };
        }
        #endregion
    }
}
