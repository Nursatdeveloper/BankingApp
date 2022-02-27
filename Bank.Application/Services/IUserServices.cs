using Bank.Application.Commands.UserCommands;
using Bank.Core.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public interface IUserServices
    {
        Task<string> GenerateCardNumber();
        User FindUserForLogin(LoginUserCommand request);
        ClaimsIdentity GenerateClaimsIdentity(User user);
        Task<string> Notify(string IIN, string notificationText);
    }
}
