using Xunit;
using Grpc.Net.Client;
using ChirpStack.Api.As.External.Api;
using System;
using System.Net.Http;
using Grpc.Core;
using System.Threading.Tasks;
using static ChirpStack.Api.Utils;

namespace ChirpStack.Api.Test
{
    public class UnitTest1
    {

        private static string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhcGlfa2V5X2lkIjoiNjJhNWU0ZTktMTNiNC00ZjViLThlZjktNmFiNjc5MzBmYTI2IiwiYXVkIjoiYXMiLCJpc3MiOiJhcyIsIm5iZiI6MTYzOTA0ODkzMCwic3ViIjoiYXBpX2tleSJ9.-APe7h7BlYtBlFCez33aC2OmvUKvXsGLAANdLG07PK0";

        [Fact]  
        public void Test1()
        {
            // using var channel = GrpcChannel.ForAddress("http://192.168.233.12:8080", new GrpcChannelOptions
            // {
            //     Credentials = ChannelCredentials.Create()
            // });

            using var channel = CreateAuthenticatedChannel("https://192.168.233.12:8080", _token, true);

            var client = new ApplicationService.ApplicationServiceClient(channel);
            var response = client.List( new ListApplicationRequest {

            });
            Console.WriteLine(response.TotalCount);

            // var client = new DeviceQueueService.DeviceQueueServiceClient(channel);
            
        }
    }
}

