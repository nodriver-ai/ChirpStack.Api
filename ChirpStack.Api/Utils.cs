using Grpc.Net.Client;
using System.Net.Http;
using Grpc.Core;
using System.Threading.Tasks;

namespace ChirpStack.Api
{
    public static class Utils
    {
        public static GrpcChannel CreateAuthenticatedChannel(string address, string token, bool allowUnthrusted = false)
        {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(token))
                {
                    metadata.Add("Authorization", $"Bearer {token}");
                    // metadata.Add("authorization-data", $"Bearer {_token}");
                }
                return Task.CompletedTask;
            });
            
            if (allowUnthrusted)
            {
                var httpClientHandler = new HttpClientHandler();
                // Return `true` to allow certificates that are untrusted/invalid
                httpClientHandler.ServerCertificateCustomValidationCallback = 
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var httpClient = new HttpClient(httpClientHandler);
                return GrpcChannel.ForAddress(address, new GrpcChannelOptions 
                    { 
                        HttpClient = httpClient, 
                        Credentials = ChannelCredentials.Create(new SslCredentials(), credentials) 
                    });
            }
            else
            {
                // SslCredentials is used here because this channel is using TLS.
                // CallCredentials can't be used with ChannelCredentials.Insecure on non-TLS channels.
                return GrpcChannel.ForAddress(address, new GrpcChannelOptions
                {
                    // Credentials = ChannelCredentials.Create(ChannelCredentials.Insecure, credentials)
                    Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
                });
            }
        }
    }
}