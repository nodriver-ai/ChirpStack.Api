using Xunit;
using Grpc.Net.Client;
using ChirpStack.Api.As.External.Api;

namespace ChirpStack.Api.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        using var channel = GrpcChannel.ForAddress("localhost:8883");

        var client = new DeviceQueueService.DeviceQueueServiceClient(channel);
        
    }
}