using Grpc.Core;
using Server;

namespace Server.Services
{
    public class GreeterService : GrpcData.Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<GrpcData.HelloReply> SayHello(GrpcData.HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GrpcData.HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
