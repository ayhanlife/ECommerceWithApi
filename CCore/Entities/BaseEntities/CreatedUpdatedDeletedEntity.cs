namespace Core.Entities.BaseEntities
{
    public class CreatedUpdatedDeletedEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, ISoftDeleteEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isDeleted { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
