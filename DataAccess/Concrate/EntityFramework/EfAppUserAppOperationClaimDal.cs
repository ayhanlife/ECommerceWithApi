using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.Contexts;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{

    public class EfAppUserAppOperationClaimDal : EfBaseRepository<AppUserAppOperationClaim, ECommerceDbContext>, IAppUserAppOperationClaimDal
    {

        private readonly ECommerceDbContext context;
        public EfAppUserAppOperationClaimDal(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
