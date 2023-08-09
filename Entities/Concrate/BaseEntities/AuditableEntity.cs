using Entities.Abstract;

namespace Entities.Concrate.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public int UpdateUserId { get; set ; }
        public DateTime? UpdatedDate  { get; set ; }

        public int CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
