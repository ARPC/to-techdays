using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // fdef2e62-9f45-4225-a397-5578b49a6e66
            // 48d1e34c-5946-4294-a1d7-89d35f1ae990

            var redis = ConnectionMultiplexer.Connect("localhost");
            var redisCache = redis.GetDatabase();

            // var theObj = new ObjectToSerialize {
            //     Id = Guid.NewGuid(),
            //     Name = "My Name Is Inigo Montoya",
            //     TheDate = DateTime.UtcNow,
            //     Counter = 42
            // };

            // //var jsonObj = JsonConvert.SerializeObject(theObj);
            
            // byte[] binaryObj = ObjectToByteArray(theObj);

            // redisCache.StringSet(theObj.Id.ToString(), binaryObj);

            // Console.WriteLine(theObj.Id.ToString());

            string jsonObj = redisCache.StringGet("fdef2e62-9f45-4225-a397-5578b49a6e66");

            var theObj = JsonConvert.DeserializeObject<ObjectToSerialize>(jsonObj);

            Console.WriteLine($"Name: {theObj.Name}");
            Console.WriteLine($"Date: {theObj.TheDate}");
            Console.WriteLine($"Counter: {theObj.Counter}");
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
