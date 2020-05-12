using SMS.DATA.Infrastructure;
using SMSContext = SMS.DATA.Models.SMS;

namespace SMS.DATA.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext Context { get; }

        public UnitOfWork()
        {
            Context = new SMSContext();
        }
        public void Commit()
        {
            Context.SaveChanges();
        }



    }
}
