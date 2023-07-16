

namespace RedisModification
{
    public static class RedisClrFunction
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static bool Connect(string server = "localhost", string port = "6379")
        {
            return true;
        }
        //public static string GetKey(string keyName)
        //{
        //    return keyName;
        //}
        [Microsoft.SqlServer.Server.SqlFunction]
        public static string GetValue(string keyName)
        {
            return keyName+ "_Value";
        }
    }
}
