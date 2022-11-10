namespace Shared.Authentication
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse.Login.Any> Login(AuthenticationRequest.Login);
        public Task<AuthenticationResponse.Register.Any> Register(AuthenticationRequest.Register);
    }
}
