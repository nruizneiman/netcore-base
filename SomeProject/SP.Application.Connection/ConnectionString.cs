namespace SP.Application.Connection
{
    public static class ConnectionString
    {
        private static string Server => @"(localdb)\mssqllocaldb";
        private static string DataBase => @"SomeProject";

        public static string CurrentConnectionString => $"Server={Server};Database={DataBase};Trusted_Connection=True;";
    }
}
