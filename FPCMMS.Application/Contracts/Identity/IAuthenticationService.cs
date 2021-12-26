using FPCMMS.Application.DTOs;

namespace FPCMMS.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<AuthenticationResponse> CreateToken();
    }
}
