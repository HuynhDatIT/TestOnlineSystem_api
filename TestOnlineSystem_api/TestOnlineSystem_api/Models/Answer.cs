using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContentAnswer { get; set; }
        [Required]
        public bool Istrue { get; set; }
        public string PathImage { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
    }
}
