namespace ArchitectureDDD.Domain
{
    public class UserLogin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
