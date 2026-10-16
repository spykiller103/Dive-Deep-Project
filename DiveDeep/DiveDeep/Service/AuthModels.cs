namespace DiveDeep.Service
{
    // Svaret fra Identity API'ets /login endpoint.
    public class AccessTokenResponse
    {
        public string TokenType { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public long ExpiresIn { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }

    // Fejlsvaret (ValidationProblem) fra Identity API'ets /register endpoint.
    public class IdentityProblemResponse
    {
        public string? Title { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
    }
}
