using Core.Entities.Concrate;

namespace Entities.Concrate
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim ()
        {
            AppUserAppOperationClaims = new HashSet<AppUserAppOperationClaim>();    
        }
        public virtual ICollection<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }
}
