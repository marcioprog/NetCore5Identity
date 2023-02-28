using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _singInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> singInManager, TokenService tokenService)
        {
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentiTy = _singInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentiTy.Result.Succeeded)
            {
                var identityUser = _singInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login Falhou");
        }
    }
}
