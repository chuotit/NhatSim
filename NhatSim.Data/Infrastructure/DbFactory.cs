namespace NhatSim.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NhatSimDbContext dbContext;

        public NhatSimDbContext Init()
        {
            return dbContext ?? (dbContext = new NhatSimDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}