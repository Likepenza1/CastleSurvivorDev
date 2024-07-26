namespace Server.ServerCore.App
{
    public class AppPath
    {
        public static string SertificatePath;
        
        public static string Get()
        {
            var strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return System.IO.Path.GetDirectoryName(strExeFilePath) + "/";
        }
        
        public static string Get(string localPath)
        {
            return Get() + localPath;
        }
    }
}