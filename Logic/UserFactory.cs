namespace Hotell567.Logic

{
    public class UserFactory
    {
        private const int minimumUsernameLength = 4;
        private const int minimumPasswordLength = 8;


        public bool CheckIfCredentialsAreCorrect(string username, string password)
        {
            var user = AppManager.userDatabase.CheckDBForUser(username);

            if (user.username == username && user.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfUsernameExists(string username)
        {
            var user = AppManager.userDatabase.CheckDBForUser(username);

            if (user.username == username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfAccountFieldsAreValid(string username, string password, string email)
        {
            if (IsValidUsername(username) == false)
            {
                return false;
            }
            if (IsValidEmail(email) == false)
            {
                return false;
            }
            if (IsValidPassword(password) == false)
            {
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            if (password.Length < minimumPasswordLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;

            if (username.Length < minimumUsernameLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
