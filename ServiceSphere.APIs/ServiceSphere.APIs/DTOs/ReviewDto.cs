using ServiceSphere.core.Entities.Assessments;

namespace ServiceSphere.APIs.DTOs
{
    public class ReviewDto
    {
        public string Description { get; set; }
        public string TargetUserId { get; set; }
        public Rating Rating { get; set; }
    }

}
