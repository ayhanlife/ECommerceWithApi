namespace Core.Entity.Abstract
{
    public interface IUpdatedEntity
    {
        int UpdateUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
