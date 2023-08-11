using Core.Entities.Concrate;
using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.Contexts;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfAppUserDal : EfBaseRepository<OperationClaim, ECommerceDbContext>, IAppUserDal
    {

        private readonly ECommerceDbContext context;
        public EfAppUserDal(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
