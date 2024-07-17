﻿using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Domain.ViewModel
{
    public class RecentReportPhoneNumberByType
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public long TimesReported { get; set; }
        public long Views { get; set; }

        public Reports Reports { get; set; }
        public TypeOfReports TypeOfReports { get; set; }
    }
}
