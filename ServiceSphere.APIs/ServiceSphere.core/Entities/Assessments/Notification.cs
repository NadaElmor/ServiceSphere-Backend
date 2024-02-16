using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Assessments
{
    public enum NotificationStatus
    {
        Unread,
        Read,
        Archived,
        deleted
    }
    public class Notification:BaseEntity
    {
        public string Message { get; set; }
        public DateTime date { get; set; }
       // public NotificationStatus Status { get; set; }

        //fk for user
        //public string? ClientId { get; set; }
        //public Client Client { get; set; }

        //public string? FreelancerId { get; set; }
        //public Freelancer  Freelncer { get; set; }

        public string UserId { get; set; }

    }
}
