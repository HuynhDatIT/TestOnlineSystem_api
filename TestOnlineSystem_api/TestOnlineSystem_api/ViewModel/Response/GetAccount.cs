using Mini_project_API.Models;

namespace Mini_project_API.ViewModel.Response
{
    public class GetAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
        public bool IsBlock { get; set; }
    }
}
