using EventStore.Client;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservice_LoadBalancer_Trial
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpClient _client = new HttpClient();
            //try
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine(_client.GetStringAsync("https://localhost:44346/c57abc28-4aad-11eb-b378-0242ac130002").Result);
            //        Console.WriteLine("\n\n");
            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(string.Format("Task failed due to: {0}", exception.Message));
            var settings = EventStoreClientSettings
    .Create("esdb://localhost:2113?Tls=false");
            var client = new EventStoreClient(settings);

            var evt = new
            {
                EntityId = Guid.NewGuid().ToString("N"),
                ImportantData = "I wrote my first event!"
            };

            var eventData = new EventData(
                Uuid.NewUuid(),
                "TestEvent",
                JsonSerializer.SerializeToUtf8Bytes(evt)
            );

            Task.WaitAll(client.AppendToStreamAsync(
    "some-stream",
    StreamState.Any,
    new[] { eventData }
));

            var result = client.ReadStreamAsync(
    Direction.Forwards,
    "some-stream",
    StreamPosition.Start);

            var events = result.ToListAsync().Result;

            foreach (var item in events)
            {
                Console.WriteLine(item.OriginalEvent.Data.ToString());
                Console.WriteLine(item.OriginalEvent.EventStreamId);
                Console.WriteLine(item.OriginalEvent.Created);
                Console.WriteLine(item.Event.Data.ToString());
            }

            Console.ReadKey();
        }
    }
}
