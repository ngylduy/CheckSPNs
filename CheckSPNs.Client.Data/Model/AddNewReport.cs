using System.ComponentModel.DataAnnotations;

namespace CheckSPNs.Client.Data.Model
{
    public class AddNewReport
    {
        public Guid TypeOfReport { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
