using Fiap.Api.Residuos.Models;

namespace Fiap.Api.Residuos.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "usuario01", Password = "pass123", Role = "user" },
                    new UserModel { UserId = 2, Username = "gerente01", Password = "pass123", Role = "gerente" },
                    new UserModel { UserId = 3, Username = "admin", Password = "admin", Role = "admin" },
                };
        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username & u.Password == password);
        }
    }
}
