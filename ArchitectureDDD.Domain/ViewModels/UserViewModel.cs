using System.Collections.Generic;

namespace ArchitectureDDD.Domain
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool ChangePassword { get; set; }
        public string NewPasswordToken { get; set; }
    }
}
