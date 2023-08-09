using DataAccess.Abstract;
using DataAccess.Concrate.Contexts;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserDal : EfBaseRepository<User, ECommerceDbContext>, IUserDal
    {

        private readonly ECommerceDbContext context;
        public EfUserDal(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
