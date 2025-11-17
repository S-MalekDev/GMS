

namespace CoreLayer.Entities
{
    public class Job
    {
        public short JobId { get; set; }

        public string JobTitle { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
