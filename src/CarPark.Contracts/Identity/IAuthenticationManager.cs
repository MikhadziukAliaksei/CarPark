using CarPark.EntitiesDto.Identity;
using System.Threading.Tasks;

namespace CarPark.Contracts.Identity
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
