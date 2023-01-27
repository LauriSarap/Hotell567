using Hotell567.Data;
using System.Diagnostics;

namespace Hotell567.Logic
{
    public static class AppManager
    {
        public static bool isInitialized = false;

        public static string dbFile = "hoteldatabase.db";
        public static string solutionFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\"));
        public static string dbFilePath = Path.Combine(solutionFolder, dbFile);
        public static string connectionString = $"Data Source={dbFilePath}";

        public static UserDatabase userDatabase;
        public static UserFactory userFactory;

        static AppManager()
        {
            Debug.WriteLine("AppManager created");

            Debug.WriteLine("dbPatch is: " + dbFilePath);


            // User logic setup
            userDatabase = new UserDatabase();
            userFactory = new UserFactory();

            // Room logic setup
        }
    }
}
