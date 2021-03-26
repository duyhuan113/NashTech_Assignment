using System.ComponentModel.DataAnnotations;
namespace demoManageMembers.Models
{
    public class User
    {
        [Required]
        public int UserId {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        public string Password {get;set;}
        public int RoleId {get;set;} 
    }
    public class Role
    {
        public int Id {get;set;}
        public string RoleName{get;set;}
    }
}

