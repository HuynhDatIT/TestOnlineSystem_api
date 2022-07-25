using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContentQuestion { get; set; }
        public bool IsOnlyAnswer { get; set; } 
        public string PathImage { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
       
    }
}
