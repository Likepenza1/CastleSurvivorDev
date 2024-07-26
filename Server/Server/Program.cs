using Server.ServerCore;
using Server.ServerCore.App;
using Server.ServerCore.Startup;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                AppPath.SertificatePath = args[0];
            }

            var context = new ServerContext();
            var controller = new StartController(context);
            
            controller.Activate();
        }
    }
}