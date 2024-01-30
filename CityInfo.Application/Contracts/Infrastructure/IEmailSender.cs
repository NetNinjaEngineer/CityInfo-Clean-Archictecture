using CityInfo.Application.Models;
using System.Threading.Tasks;

namespace CityInfo.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
