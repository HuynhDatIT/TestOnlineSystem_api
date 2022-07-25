using System.Collections.Generic;

namespace Mini_project_API.ViewModel.Response
{
    public class GetQuestion
    {
        public int Id { get; set; }
        public string ContentQuestion { get; set; }
        public bool IsOnlyAnswer { get; set; }
        public string PathImage { get; set; }
        public int MyProperty { get; set; }
        public IList<GetAnswer> Answers { get; set; }
    }
}
