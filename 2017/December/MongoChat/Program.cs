using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoChat.Dto;
using MongoDB.Bson.Serialization;

namespace MongoChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            MapDtoObjects();
        }

        public static void MapDtoObjects()
        {
            BsonClassMap.RegisterClassMap<InstantMessage>(cm => 
            {
                cm.MapIdMember(c => c.Id);
                cm.MapMember(c => c.Created);
                cm.MapMember(c => c.Sender);
                cm.MapMember(c => c.Body);
            });
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
