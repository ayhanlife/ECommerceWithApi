namespace Entities.Abstracr
{
    public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime? CreatedDate { get; set; }
    }
}
