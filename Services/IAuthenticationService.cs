using System.Threading.Tasks;
using fitness_tracker_serverside.Dtos;

namespace fitness_tracker_serverside.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(Register request);
        Task<string> Login(Login request);
    }
}
