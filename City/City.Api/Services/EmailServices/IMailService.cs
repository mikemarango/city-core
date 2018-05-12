using System.Threading.Tasks;

namespace City.Api.Services.EmailServices
{
    public interface IMailService
    {
        Task SendEmailAsync(string subject, string message);
    }
}