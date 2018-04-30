using System;

namespace RedisApp
{
    [Serializable]
    public class ObjectToSerialize
    {
        public string Name { get; set; }
        public DateTime TheDate { get; set; }
        public int Counter { get; set; }
        public Guid Id { get; set; }
    }
}