namespace Mini_project_API.ViewModel.Request
{
    public class CreateAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int RoleId { get; set; }
    }
}
