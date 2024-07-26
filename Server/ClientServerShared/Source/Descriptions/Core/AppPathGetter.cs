namespace Descriptions.Core
{
    public static class AppPathGetter
    {
        public static string Get()
        {
            var strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return System.IO.Path.GetDirectoryName(strExeFilePath) + "/";
        }
    }
}