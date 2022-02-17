using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gem.Backend.Login
{
    public class Person
    {
        /// <summary>
        /// Enum for Return codes
        /// </summary>
        public enum ReturnCode
        {
            SUCCESS = 0,
            CANNOT_BE_NULL,
            PASSWORD_TOO_SHORT,
            INCORRECT_EMAIL_FORMAT
        }
        public enum Status
        {
            OFFLINE = 0,
            ONLINE
        }
        private static int minimumPasswordLength = 5;
        public string FirstName { get; private set; } = null;
        public string MiddleName { get; private set; } = null;
        public string LastName { get; private set; } = null;
        public string Email { get; private set; } = null;
        public string Password { get; private set; } = null;
        public Status ConnectionStatus { get; private set; }
        public ReturnCode SetFirstName(string firstName)
        {
            if (firstName == null)
                return ReturnCode.CANNOT_BE_NULL;
            FirstName = firstName;
            return ReturnCode.SUCCESS;
        }
        public void SetMiddleName(string middleName = null)
        {
            MiddleName = middleName;
        }
        public ReturnCode SetLastName(string lastName)
        {
            if (lastName == null)
                return ReturnCode.CANNOT_BE_NULL;
            LastName = lastName;
            return ReturnCode.SUCCESS;
        }
        public ReturnCode SetEmail(string email)
        {
            if (email == null)
                return ReturnCode.CANNOT_BE_NULL;
            if (!email.Contains('@'))
                return ReturnCode.INCORRECT_EMAIL_FORMAT;
            Email = email;
            return ReturnCode.SUCCESS;
        }
        public ReturnCode SetPassword(string password)
        {
            if (password == null)
                return ReturnCode.CANNOT_BE_NULL;
            if (password.Length < minimumPasswordLength)
                return ReturnCode.PASSWORD_TOO_SHORT;
            Password = password;
            return ReturnCode.SUCCESS;
        }
        public Status SetConnectionStatus(Status status)
            => ConnectionStatus = status;
    }
}
