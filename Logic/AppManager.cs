using Hotell567.Data;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Hotell567.MVVM;

namespace Hotell567.Logic
{
    public static class AppManager
    {
        // AppManager status
        public static bool isInitialized = false;

        // Database configurations
        public static string dbFile = "hoteldatabase.db";
        public static string solutionFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\"));
        public static string dbFilePath = Path.Combine(solutionFolder, dbFile);
        public static string connectionString = $"Data Source={dbFilePath}";

        // Static instances
        public static UserDatabase userDatabase;
        public static UserFactory userFactory;

        // User data
        public static User currentUser;

        static AppManager()
        {
            Debug.WriteLine("AppManager created");

            Debug.WriteLine("dbPatch is: " + dbFilePath);


            // User logic setup
            userDatabase = new UserDatabase();
            userFactory = new UserFactory();

            // Room logic setup
        }

        public static void InitializePermissions(int permissionLevel)
        {
            if (permissionLevel == 0)
            {
                // User
                Debug.Write("Default Permissions!");
            }
            else if (permissionLevel == 1)
            {
                // Admin
                Debug.Write("Admin Permissions!");
                AppShell.GetSingleton.ShowPagesAfterLogin();
            }
        }

        public static void InitializeUserData(User u)
        {
            currentUser = u;
        }
    }
}
