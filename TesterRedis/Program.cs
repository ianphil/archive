using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TesterRedis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase db = redis.GetDatabase();

            string key = "name";
            string val = "Ian Philpot";
            db.StringSet(key, val);

            string result = db.StringGet(key);

            Console.WriteLine("Hello my name is: " + result);
            Console.ReadKey();
        }
    }
}
