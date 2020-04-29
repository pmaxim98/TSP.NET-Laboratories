using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

using GrpcPostComment;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var httpClient = new HttpClient(httpClientHandler);
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });

            var client = new gRPCPostCommentService.gRPCPostCommentServiceClient(channel);

            await client.SubmitPostAsync(new PostMessage()
            {
                Description = "TestDescription",
                Domain = "TestDomain",
                Date = "TestDate"
            });

            PostsResponse postsResponse = await client.GetAllPostsAsync(new NoParamsMessage());

            Console.WriteLine("All posts: ");

            foreach (PostMessage postMessage in postsResponse.Posts)
                Console.WriteLine(postMessage);

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }
    }
}
