using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mini_project_API.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime TestDay { get; set; }
        public ulong Minute { get; set; }
        public uint MaxScores { get; set; }
        public ICollection<TestAccount> TestAccounts { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
        
    }
}
