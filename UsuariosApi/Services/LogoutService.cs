using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace UsuariosApi.Services
{
   
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<int>> signinManager)
        {
            _signinManager = signinManager;
        }

        public  Result DeslogaUsuario()
        {
            var resultadoIdentity = _signinManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();

            return Result.Fail("Logout falhou");
        }
    }
}
