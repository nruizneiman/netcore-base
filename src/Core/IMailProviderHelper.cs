using System.Threading.Tasks;

namespace Core
{
    public interface IMailProviderHelper
    {
        Task SendAsync(Mail mail);
    }

    public class Mail
    {
        public string To { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
