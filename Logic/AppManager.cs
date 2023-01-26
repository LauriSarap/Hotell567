using Hotell567.Data;
using System.Data.SQLite;

namespace Hotell567.Logic
{
    public static class AppManager
    {
        public static UserDatabase userDatabase;
        public static UserFactory userFactory;

        static AppManager()
        {
            // This piece of code has to be the first that accesses the .db file!

            /*var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            
            using (Stream stream = assembly.GetManifestResourceStream("Hotell567.hoteldatabase.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(DbPath, memoryStream.ToArray());
                }
            }*/

            // User logic setup
            userDatabase = new UserDatabase(DbPath);
            userFactory = new UserFactory();

            // Room logic setup
        }
    }
}
