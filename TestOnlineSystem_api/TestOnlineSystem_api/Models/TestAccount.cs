using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class TestAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Scores { get; set; }
        [Required]
        public bool IsComplete { get; set; }
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
