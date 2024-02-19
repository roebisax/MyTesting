using Grpc.Core;
using Grpc.Net.Client;
using GrpcData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ChatService
    {
        public async Task Handle(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {

                Debug.WriteLine("Start Client");
                GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7001");


                Debug.WriteLine("client created");

                var headers = new Metadata();

                try
                {

                    var authenticationClient = new Authentication.AuthenticationClient(channel);

                    var authenticationReply = await authenticationClient.AuthenticateAsync(new AuthenticationRequest { Username = "admin", Password = "admin" });

                    headers.Add("Authorization", $"Bearer {authenticationReply.AccessToken}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Chat.ChatClient client = new (channel);
                using AsyncDuplexStreamingCall<ToServerDto, ToClientDto> call = client.Chatter(headers);

                Task readTask = Task.Run(async () =>
                {
                    await foreach(ToClientDto toClientDto in call.ResponseStream.ReadAllAsync())
                    {
                        Debug.WriteLine("Empfangen");
                        Console.WriteLine(toClientDto.Text);
                    }
                }, cancellationToken);

                while(!cancellationToken.IsCancellationRequested)
                {
                    string? txt = Console.ReadLine();
                    Debug.WriteLine("Start schreiben");
                    await call.RequestStream.WriteAsync(new ToServerDto() { Text = txt ?? "no Data" });
                }

                await call.RequestStream.CompleteAsync();
                await readTask;
                //await channelState;

            });
        }
    }
}
