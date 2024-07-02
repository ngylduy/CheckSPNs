using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Data.EF.Implementations
{
    public class PhoneNumberRepository : Repository<PhoneNumbers>, IPhoneNumberRepository
    {
        private readonly CheckSPNsContext _context;

        public PhoneNumberRepository(CheckSPNsContext context) : base(context)
        {
            _context = context;
        }

        public Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber)
        {
            return _context.Set<PhoneNumbers>().Include(p => p.Reports).FirstOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber));
        }
    }
}
