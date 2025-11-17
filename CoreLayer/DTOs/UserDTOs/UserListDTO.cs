

namespace CoreLayer.DTOs.UserDTOs
{
    public class UserListDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;         
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
