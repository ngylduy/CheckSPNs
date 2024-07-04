namespace CheckSPNs.Domain.Exceptions
{
    public class PhoneNumberNotFoundException : NotFoundException
    {
        public PhoneNumberNotFoundException(Guid phoneNumber)
            : base($"The phone number {phoneNumber} was not found.")
        {
        }
    }
}
