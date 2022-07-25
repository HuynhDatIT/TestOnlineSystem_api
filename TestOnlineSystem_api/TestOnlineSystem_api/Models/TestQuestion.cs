using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class TestQuestion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
