namespace DiveDeep.Service
{
    // Holder på det bearer token, som API'et returnerer ved login.
    // Tokenet ligger kun i hukommelsen og forsvinder ved genindlæsning af siden.
    public class AuthState
    {
        public string? AccessToken { get; private set; }
        public string? Email { get; private set; }
        public bool IsLoggedIn => AccessToken is not null;

        public event Action? Changed;

        public void SignIn(string email, string accessToken)
        {
            Email = email;
            AccessToken = accessToken;
            Changed?.Invoke();
        }

        public void SignOut()
        {
            Email = null;
            AccessToken = null;
            Changed?.Invoke();
        }
    }
}
