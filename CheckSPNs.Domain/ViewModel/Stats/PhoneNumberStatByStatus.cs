namespace CheckSPNs.Domain.ViewModel.Stats
{
    public class PhoneNumberStatByStatus
    {
        public long Positive { get; set; }
        public long Negative { get; set; }
        public long Neutral { get; set; }

        public double PositivePercent { get; set; }
        public double NegativePercent { get; set; }
        public double NeutralPercent { get; set; }

        public long Total { get; set; }
    }
}
