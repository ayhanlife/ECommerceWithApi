using Core.Entities.Concrate;

namespace Entities.Concrate
{
    public class AppUser : User
    {
        public AppUser()
        {
            AppUserAppOperationClaims = new HashSet<AppUserAppOperationClaim>();

        }
        public Guid? RefreshToken { get; set; }
        public virtual ICollection<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }

}
