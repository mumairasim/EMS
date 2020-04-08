

using SMS.DATA.Infrastructure;

namespace SMS.DATA.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext Context { get; }

        public UnitOfWork(IDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }



    }
}
