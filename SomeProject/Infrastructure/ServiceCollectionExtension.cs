using Core;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            if (!string.IsNullOrEmpty(Configuration.GetConnectionString("DefaultConnection")))
            {
                services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.EnableRetryOnFailure()));
            }
            else
            {
                // For development usage only
                services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SomeProject;Trusted_Connection=True;MultipleActiveResultSets=true"));
            }

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMailProviderHelper, MailProviderHelper>(serviceProvider => BuildMailProvider());

            return services;
        }

        private static MailProviderHelper BuildMailProvider()
        {
            string senderName = Configuration.GetValue<string>("EmailConfiguration:SenderName");
            string senderEmail = Configuration.GetValue<string>("EmailConfiguration:SenderEmail");
            string smtpHost = Configuration.GetValue<string>("EmailConfiguration:SmtpHost");
            int smtpPort = Configuration.GetValue<int>("EmailConfiguration:SmtpPort");
            string smtpUserName = Configuration.GetValue<string>("EmailConfiguration:SmtpUserName");
            string smtpPassword = Configuration.GetValue<string>("EmailConfiguration:SmtpPassword");
            bool useSsl = Configuration.GetValue<bool>("EmailConfiguration:UseSsl");

            return new MailProviderHelper(new SmtpClient(), senderName, senderEmail, smtpHost, smtpPort, smtpUserName, smtpPassword, useSsl);
        }
    }
}
