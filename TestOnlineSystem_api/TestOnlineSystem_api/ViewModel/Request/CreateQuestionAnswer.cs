using Mini_project_API.Models;
using System.Collections.Generic;

namespace Mini_project_API.ViewModel.Request
{
    public class CreateQuestionAnswer
    {
        public string ContentQuestion { get; set; }
        public bool IsOnlyAnswer { get; set; }
        public string PathImage { get; set; }
        public ICollection<PostAnswer> PostAnswers { get; set; }
    }

}
