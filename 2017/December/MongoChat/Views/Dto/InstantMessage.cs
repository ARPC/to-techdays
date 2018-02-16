using System;
using MongoDB.Bson;

namespace MongoChat.Dto
{
    public class InstantMessage
    {
        public ObjectId Id;
        public DateTime Created;
        public string Sender;
        public string Body;
    }
}