using Xunit;
using Grpc.Net.Client;
using ChirpStack.Api.As.External.Api;
using System;
using System.Net.Http;
using Grpc.Core;
using System.Threading.Tasks;

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

                using var channel = CreateAuthenticatedChannel("https://192.168.233.12:8080");

                var client = new ApplicationService.ApplicationServiceClient(channel);
                var response = client.List( new ListApplicationRequest {

                });
                Console.WriteLine(response.TotalCount);

                // var client = new DeviceQueueService.DeviceQueueServiceClient(channel);
                
            }

            private static GrpcChannel CreateAuthenticatedChannel(string address)
            {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    metadata.Add("Grpc-Metadata-Authorization", $"Bearer {_token}");
                    // metadata.Add("authorization-data", $"Bearer {_token}");
                }
                return Task.CompletedTask;
            });

            var httpClientHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpClientHandler.ServerCertificateCustomValidationCallback = 
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpClientHandler);
            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions 
                { 
                    HttpClient = httpClient, 
                    Credentials = ChannelCredentials.Create(new SslCredentials(), credentials) 
                });

            // SslCredentials is used here because this channel is using TLS.
            // CallCredentials can't be used with ChannelCredentials.Insecure on non-TLS channels.
            // var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            // {
            //     // Credentials = ChannelCredentials.Create(ChannelCredentials.Insecure, credentials)
            //     Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            // });
            return channel;
        }
    }
}

