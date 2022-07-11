using System.Security.Cryptography;


namespace Authentication
{
    public enum AccountCreationError
    {
        Ok = 0,
        Short = 1,
        Bad = 2
    }

    public class Account
    {
        public string? UserName { get; init; }
        public string? Password { get; set; }
        public Account(string _username)
        {
            UserName = _username;
        }

        public AccountCreationError MakePassword(string _password)
        {

            AccountCreationError result = PasswordIsOk(_password);

            if(result == AccountCreationError.Ok)
            {
                Password = _password;
            }

            return result;
        }

        public AccountCreationError PasswordIsOk(string _password)
        {
            return AccountCreationError.Ok;
        }

    }


}