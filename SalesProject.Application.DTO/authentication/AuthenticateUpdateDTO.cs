namespace SalesProject.Application.DTO.authentication
{
    public class AuthenticateUpdateDTO
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
    }
}
