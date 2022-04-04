
using StackExchange.Redis;
using System;
using System.Threading.Tasks;



ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints = { "localhost:6379" }
            });

    var db = redis.GetDatabase();
    var pong = await db.PingAsync();
    Console.WriteLine(pong);

Console.WriteLine("Enter a Key: ");
string? key = Console.ReadLine();
Console.WriteLine("Enter a value: ");
string? value = Console.ReadLine();


db.StringSet(key, value);


while (true)
{
    string searchValue = Console.ReadLine();


    if(db.StringGet(searchValue).ToString() == null)
    {
        Console.WriteLine("No Record Found");
    }
    else
    {
        Console.WriteLine("You found me!!! >> " + db.StringGet(searchValue).ToString());
        Console.ReadLine();
        break;
    }
}