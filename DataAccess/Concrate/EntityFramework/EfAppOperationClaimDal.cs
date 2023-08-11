using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.Contexts;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{

    public class EfAppOperationClaimDal : EfBaseRepository<AppOperationClaim, ECommerceDbContext>, IAppOperationClaimDal
    {

        private readonly ECommerceDbContext context;
        public EfAppOperationClaimDal(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
