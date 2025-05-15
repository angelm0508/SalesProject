using System.Net.Security;

namespace SalesProject.Transversal.Common
{
    public class AuthenticateResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
