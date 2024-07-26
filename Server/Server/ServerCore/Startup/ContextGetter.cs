namespace Server.ServerCore.Startup
{
    public static class ContextGetter
    {
        public static ServerContext Context { get; private set; }

        public static void Init(ServerContext context)
        {
            Context = context;
        }
    }
}