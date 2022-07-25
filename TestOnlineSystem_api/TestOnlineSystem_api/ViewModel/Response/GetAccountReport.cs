using Mini_project_API.Enum;

namespace Mini_project_API.ViewModel.Response
{
    public class GetAccountReport
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Scores { get; set; }
        public string Rank { get; set; }
    }
}
