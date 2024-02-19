using Grpc.Net.Client;
using GrpcData;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Task.Run(() => new ChatService().Handle(new CancellationToken())).Wait();

            Console.WriteLine("Fertig");

        }
    }
}
