using Application.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserModel> Register();
    }

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<UserModel> Register()
        {
            throw new System.NotImplementedException();
        }
    }
}
