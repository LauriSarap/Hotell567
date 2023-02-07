using Hotell567.Data;
using System.Diagnostics;
using Hotell567.Models;

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

        public static RoomDatabase roomDatabase;
        //TODO Implement later
        // public static RoomFactory roomFactory;
        public static RoomFiltering roomFiltering;


        public static ReservationDatabase reservationDatabase;
        public static ReservationFactory reservationFactory;

        // User data
        public static User currentUser;

        static AppManager()
        {
            Debug.WriteLine("AppManager created");

            if (File.Exists(dbFilePath))
            {
                Debug.WriteLine("Found database at: " + dbFilePath);
            }
            else
            {
                Debug.WriteLine("Failed to find database!");
            }


            // User logic setup
            userDatabase = new UserDatabase();
            userFactory = new UserFactory();

            // Room logic setup
            roomDatabase = new RoomDatabase();

            roomFiltering = new RoomFiltering();

            // Reservation logic setup
            reservationDatabase = new ReservationDatabase();
            reservationFactory = new ReservationFactory();
        }

        public static void InitializePermissions(int permissionLevel)
        {
            if (permissionLevel == 0)
            {
                // User
                Debug.WriteLine("Default Permissions!");
            }
            else if (permissionLevel == 1)
            {
                // Admin
                Debug.WriteLine("Admin Permissions!");
                AppShell.GetSingleton.ShowPagesAfterLogin();
            }
        }

        public static void InitializeUserData(User u)
        {
            currentUser = u;
        }
    }
}
