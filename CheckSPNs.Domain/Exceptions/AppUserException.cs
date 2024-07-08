namespace CheckSPNs.Domain.Exceptions;

public static class AppUserException
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(object email)
        : base($"The user {email} was not found.")
        {
        }
    }

    public class UserAlreadyExistsException : BadRequestException
    {
        public UserAlreadyExistsException(object email)
        : base($"The {email} already exists.")
        {
        }
    }

}
