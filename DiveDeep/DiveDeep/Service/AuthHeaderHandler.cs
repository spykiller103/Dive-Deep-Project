using System.Net.Http.Headers;

namespace DiveDeep.Service
{
    // Sætter "Authorization: Bearer <token>" på alle kald, når brugeren er logget ind.
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly AuthState authState;

        public AuthHeaderHandler(AuthState authState)
        {
            this.authState = authState;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (authState.AccessToken is not null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authState.AccessToken);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
