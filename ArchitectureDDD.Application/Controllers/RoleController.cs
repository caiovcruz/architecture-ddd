using ArchitectureDDD.Domain;
using ArchitectureDDD.Service;
using ArquictectureDDD.Application.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureDDD.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : CrudBaseController<Role, RoleViewModel, RoleValidator>
    {
        public RoleController(IRoleService roleService) : base(roleService) { }
    }
}
