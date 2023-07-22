

using StackExchange.Redis;

namespace RedisModification
{
    public static class RedisClrFunction
    {
        private static IDatabase _RedisDatabase = null;
        [Microsoft.SqlServer.Server.SqlFunction]
        public static bool Connect(string server = "localhost", string port = "6379")
        {
            try
            {

                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
                _RedisDatabase = redis.GetDatabase();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        [Microsoft.SqlServer.Server.SqlFunction]
        public static string GetValue(string keyName, string server = "localhost", string port = "6379")
        {
            if (Connect(server, port) is false)
            {
                return "اتصال به ردیس دچار مشکل گردید";

            }
            string value = _RedisDatabase.StringGet(keyName);
            return value;
        }
        public static string SetValue(string keyName, string value, string server = "localhost", string port = "6379")
        {
            if (Connect(server, port) is false)
            {
                return "اتصال به ردیس دچار مشکل گردید";
            }
            _RedisDatabase.StringSet(keyName, value);
            return $"New Value ===> {keyName}={value}" ;
        }
        public static string AddKey(string keyName, string value, string server = "localhost", string port = "6379")
        {
            if (Connect(server, port) is false)
            {
                return "اتصال به ردیس دچار مشکل گردید";
            }
            _RedisDatabase.SetAdd(keyName, value);
            return $"New Key ===> {keyName}={value}" ;
        }
        public static string RemoveKey(string keyName, string value, string server = "localhost", string port = "6379")
        {
            if (Connect(server, port) is false)
            {
                return "اتصال به ردیس دچار مشکل گردید";
            }
            _RedisDatabase.KeyDelete(keyName);
            return $"Remove Key ===> {keyName}={value}" ;
        }
    }
}
