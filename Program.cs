using Grpc.Net.Client;


internal class Program
{
    private static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://192.168.245.134:5000");
        var videoClient = new Videocapture.V1.VideoCapture.VideoCaptureClient(channel);

        var newStreamRequest = new Videocapture.V1.NewStreamRequest();

        newStreamRequest.Settings = new Videocapture.V1.StreamSettings();

        newStreamRequest.Settings.Width = 1920;
        newStreamRequest.Settings.Height = 1080;
        newStreamRequest.Settings.Format = Videocapture.V1.StreamFormat.VdoFormatJpeg;

        Console.WriteLine("Requested Video Stream Settings: " + newStreamRequest.ToString());

        Videocapture.V1.NewStreamResponse videoChannel = await videoClient.NewStreamAsync(newStreamRequest);

        Console.WriteLine(videoChannel.StreamId);

    }
}
