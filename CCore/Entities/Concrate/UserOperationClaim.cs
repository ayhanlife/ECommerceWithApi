using Core.Entities.BaseEntities;

namespace Core.Entities.Concrate
{
    public class UserOperationClaim : BaseEntity, IUpdatedEntity
    {

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
