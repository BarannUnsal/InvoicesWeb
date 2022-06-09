using System;

namespace InvoicesAPI.Business.Exceptions.Users
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Kullanıcı oluşturulurken beklenmeyen hata!")
        {
        }

        public UserCreateFailedException(string message) : base(message)
        {
        }

        public UserCreateFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
