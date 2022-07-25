using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }
      
    }
}
