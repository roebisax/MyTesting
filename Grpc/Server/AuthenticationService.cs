using Grpc.Core;
using GrpcData;

namespace Server
{
    public class AuthenticationService : Authentication.AuthenticationBase
    {
        private readonly IJwtAuthenicationManager _JwtAuthenicationManager;

        public AuthenticationService(IJwtAuthenicationManager jwtAuthenicationManager)
        {
            _JwtAuthenicationManager = jwtAuthenicationManager;
        }
        public override async Task<AuthenticationReply> Authenticate(AuthenticationRequest request, ServerCallContext context)
        {
            var authenticationReply = await _JwtAuthenicationManager.AuthenticateAsync(request);

            if (authenticationReply is null)
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid User Credentials"));

            return authenticationReply;
        }
    }
}
