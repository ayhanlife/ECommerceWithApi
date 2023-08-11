namespace Core.Entities
{
    public interface IUpdatedEntity
    {
        int UpdateUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
