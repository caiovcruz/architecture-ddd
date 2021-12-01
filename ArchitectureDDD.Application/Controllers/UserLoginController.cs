using ArchitectureDDD.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArchitectureDDD.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly ITokenService _tokenService;

        public UserLoginController(IUserLoginService userLoginService, ITokenService tokenService)
        {
            _userLoginService = userLoginService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<dynamic> Authenticate(UserLoginViewModel viewModel)
        {
            var user = _userLoginService.Login(viewModel).Result;

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido" });

            var token = _tokenService.GenerateToken(user).Result;
            user.Password = "";

            return new { user, token };
        }
    }
}
