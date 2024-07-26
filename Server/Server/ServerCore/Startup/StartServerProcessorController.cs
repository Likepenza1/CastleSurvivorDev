using System.IO;
using System.Security.Cryptography.X509Certificates;
using Core.Controllers;
using Network.Processor;
using Server.ServerCore.App;
using Server.ServerCore.Serialization;
using Server.ServerLogic;

namespace Server.ServerCore.Startup
{
    public class StartServerProcessorController : IController
    {
        private readonly ServerContext _context;

        public StartServerProcessorController(ServerContext context)
        {
            _context = context;
        }

        public void Deactivate()
        {
            _context.Network.Deactivate();
        }

        public void Activate()
        {
            var serverDescription = _context.GameRules.ServerDescription;
            var isSecure = serverDescription.IsSecure;
            var certificate = isSecure ? CreateSertificate() : null;
            
            _context.Network = new NetworkServerProcessor
            (
                new ServerHandlersFactory(), 
                _context.Serializer, 
                new Network.Server.WebSocketsGameServer(5555, serverDescription.ConnectionKey, serverDescription.IsSecure, certificate)
            );
            
            _context.Network.Activate();
        }

        private static X509Certificate2 CreateSertificate()
        {
            return X509Certificate2.CreateFromPemFile(
                AppPath.SertificatePath,
                Path.ChangeExtension(AppPath.SertificatePath, "key"));
        }
    }
}