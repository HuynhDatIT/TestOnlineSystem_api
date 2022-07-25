using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Fullname { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<TestAccount> TestAccounts { get; set; }
        public bool IsBlock { get; set; }
    }
}
