namespace ArchitectureDDD.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool ChangePassword { get; set; }
        public string NewPasswordToken { get; set; }
    }
}
