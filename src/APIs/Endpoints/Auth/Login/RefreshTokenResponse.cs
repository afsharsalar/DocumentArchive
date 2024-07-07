namespace DocumentArchive.APIs.Endpoints.Auth.Login
{
    public record RefreshTokenResponse
    {
        public string UserId { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
