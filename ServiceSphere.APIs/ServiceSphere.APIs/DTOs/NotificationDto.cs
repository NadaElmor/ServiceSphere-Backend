using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Users.Freelancer;
using ServiceSphere.core.Entities.Users;

namespace ServiceSphere.APIs.DTOs
{
    public enum NotificationStatus
    {
        Unread,
        Read,
        Archived,
        deleted
    }
    public class NotificationDto
    {
        public string Message { get; set; }
        public DateTime date { get; set; }
        public NotificationStatus Status { get; set; }

        //fk for user
        public string? ClientId { get; set; }
        //public Client Client { get; set; }

        public string? FreelancerId { get; set; }
        //public Freelancer Freelncer { get; set; }
    }
}
