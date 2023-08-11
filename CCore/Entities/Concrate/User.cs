using Core.Entities.BaseEntities;

namespace Core.Entities.Concrate
{
    public class User : CreatedUpdatedDeletedEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string GsmNumber { get; set; }
        public string ProfileImgUrl { get; set; }
        //public string? Token { get; set; }
        //public DateTime? TokenExpireDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int UserTypeId { get; set; }
    }
}
