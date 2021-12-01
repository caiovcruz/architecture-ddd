using System.ComponentModel.DataAnnotations.Schema;

namespace ArchitectureDDD.Domain
{
    public class UserRole : BaseEntity
    {
        [ForeignKey("FK_User_UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("FK_Group_GroupId")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
