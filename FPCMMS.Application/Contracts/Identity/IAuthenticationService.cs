using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace FPCMMS.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<AuthenticationResponse> CreateToken();
        Task<SignInResult> Login(UserForAuthenticationDto user);
    }
}
