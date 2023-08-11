using Core.Entities.Concrate;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrate
{
    public class AppUserAppOperationClaim : OperationClaim
    {
        public string Status { get; set; }

        [ForeignKey("OperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }


        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
