namespace CheckSPNs.API.ViewModel
{
    public class UserVM : AccountVM
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Sex { get; set; } = null!;
    }
}
