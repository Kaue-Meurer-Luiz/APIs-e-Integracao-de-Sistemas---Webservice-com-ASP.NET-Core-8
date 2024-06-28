using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}
