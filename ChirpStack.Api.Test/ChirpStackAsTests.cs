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
    public class ChirpStackAsTests
    {

        private static string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhcGlfa2V5X2lkIjoiNjJhNWU0ZTktMTNiNC00ZjViLThlZjktNmFiNjc5MzBmYTI2IiwiYXVkIjoiYXMiLCJpc3MiOiJhcyIsIm5iZiI6MTYzOTA0ODkzMCwic3ViIjoiYXBpX2tleSJ9.-APe7h7BlYtBlFCez33aC2OmvUKvXsGLAANdLG07PK0";

        private GrpcChannel _channel;

        public ChirpStackAsTests()
        {
            _channel = CreateAuthenticatedChannel("https://192.168.233.12:8080", _token, true);
        }

        [Fact]  
        public void Test1()
        {
            var client = new ApplicationService.ApplicationServiceClient(_channel);
            var response = client.List( new ListApplicationRequest {
                Limit = 1
            });
            Console.WriteLine(response.TotalCount);
            if (response.TotalCount > 0)
                Console.WriteLine(response.Result[0]);
        }

        [Fact]  
        public void Test2()
        {
            var client = new DeviceService.DeviceServiceClient(_channel);
            var response = client.List(new ListDeviceRequest
            {
                ApplicationId = 1,
                Limit = 1
            });
            Console.WriteLine(response.TotalCount);
            if (response.TotalCount > 0)
                Console.WriteLine(response.Result[0]);
        }
    }
}

