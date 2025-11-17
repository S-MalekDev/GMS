

namespace CoreLayer.Entities
{
    public class User 
    {
        public int UserID { get;  set; }
        public int PersonID { get; set; }
        public Nullable<int> CreatedByUserID { get; set; }
        public string Username { get; set; } =string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int Parmissions { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation Properties:
        public Person? PersonInfo { get; set; } 
    }
}
