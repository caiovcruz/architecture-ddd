using ArchitectureDDD.Domain;
using ArchitectureDDD.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquictectureDDD.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : CrudBaseController<User, UserViewModel, UserValidator>
    {
        public UserController(IUserService userService) : base(userService) { }

        [AllowAnonymous]
        public override IActionResult Create([FromBody] UserViewModel viewModel)
        {
            return base.Create(viewModel);
        }
    }
}
