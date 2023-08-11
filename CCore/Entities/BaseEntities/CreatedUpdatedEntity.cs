namespace Core.Entities.BaseEntities
{
    public class CreatedUpdatedEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
       
    }
}
