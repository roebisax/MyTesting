using Grpc.Core;
using GrpcData;
using Microsoft.AspNetCore.Authorization;

namespace Server
{
    [Authorize]
    public class ChatService : GrpcData.Chat.ChatBase
    {
        public override async Task Chatter(IAsyncStreamReader<ToServerDto> requestStream, IServerStreamWriter<ToClientDto> responseStream, ServerCallContext context)
        {
            Task readerTask = Task.Run(async () =>
            {
                await foreach (ToServerDto toServerDto in requestStream.ReadAllAsync())
                {
                    Console.WriteLine(toServerDto.Text);
                }
            });

            while(!context.CancellationToken.IsCancellationRequested)
            {
                string? txt = Console.ReadLine();
                await responseStream.WriteAsync(new ToClientDto { Text = txt ?? "no Data" });
            }

            await readerTask;
        }
    }
}
