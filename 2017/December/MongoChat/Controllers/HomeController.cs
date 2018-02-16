using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoChat.Models;
using MongoDB.Driver;
using MongoChat.Dto;
using MongoDB.Bson;

namespace MongoChat.Controllers
{
    public class HomeController : Controller
    {
        private string DatabaseName = "MongoChatDb";
        private string InstantMessageCollectionName = "InstantMessages";
        private IMongoCollection<InstantMessage> InstantMessageCollection;

        public HomeController(): base()
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(DatabaseName);
            InstantMessageCollection = db.GetCollection<InstantMessage>(InstantMessageCollectionName);
        }

        public void LoadMessages()
        {
            ViewData["Messages"] =
                InstantMessageCollection.Find<InstantMessage>(new BsonDocument()).ToList();
        }

        public IActionResult Index()
        {
            LoadMessages();
            return View();
        }

        public IActionResult PostMessage(string message)
        {
            InstantMessage instantMessage = new InstantMessage
            {
                Created = DateTime.Now,
                Sender = "me",
                Body = message
            };

            InstantMessageCollection.InsertOne(instantMessage);
            LoadMessages();

            ViewData["Status"] = $"Your message '{message}' has been posted.";
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
