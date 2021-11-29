using ArchitectureDDD.Domain;
using ArchitectureDDD.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquictectureDDD.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : CrudBaseController<User, UserViewModel, UserValidator>
    {
        public UserController(IBaseService<User> baseService) : base(baseService) { }
    }
}
