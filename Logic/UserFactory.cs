namespace Hotell567.Logic

{
    public class UserFactory
    {
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

            if (password.Length < 8)
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

            if (username.Length < 4)
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
