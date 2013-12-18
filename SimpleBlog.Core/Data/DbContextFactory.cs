using System.Data.Entity;

namespace SimpleBlog.Core.Data
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _dbContext;
        public DbContextFactory()
        {
            _dbContext = new Db();
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }
    }
}