

namespace CoreLayer.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public Nullable<int> CreatedByUserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Parmissions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
