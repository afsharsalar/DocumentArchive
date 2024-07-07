namespace DocumentArchive.APIs.Endpoints.Auth.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string RefreshToken { get; set; }

    }
}
