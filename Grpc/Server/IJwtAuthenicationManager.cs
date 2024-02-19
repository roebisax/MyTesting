using GrpcData;

namespace Server
{
    public interface IJwtAuthenicationManager
    {
        Task<AuthenticationReply?> AuthenticateAsync(AuthenticationRequest request);
        byte[]? GetTokenKey();
    }
}
