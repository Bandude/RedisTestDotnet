// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
{
    ISubscriber sub = redis.GetSubscriber();

    //Subscribe to the channel named messages

    sub.Subscribe("Craig", (channel, message) => {

        //Output received message
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    });
    Console.WriteLine("subscribed messages");
    Console.ReadKey();
}