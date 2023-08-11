namespace Core.Entities.BaseEntities
{
    public class UpdatedEntity : IUpdatedEntity
    {
        public int UpdateUserId { get ; set ; }
        public DateTime? UpdatedDate { get; set; }
    }
}
