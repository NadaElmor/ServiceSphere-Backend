using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Assessments
{
    public enum Rating
    {
        None = 0, // No rating
        Poor = 1,
        Fair = 2,
        Good = 3,
        VeryGood = 4,
        Excellent = 5
    }
    public class Review:BaseEntity
    {
        //public string? Description { get; set; }

       // public DateTime Date { get; set; } = DateTime.UtcNow;

        ////fk for user 
        //public int UserId { get; set; }
        //public User User { get; set; }
        //public string userID { get; set; }
        //public Rating Rating { get; set; }
        //public string? ClientId { get; set; }
        //public Client Client { get; set; }

        //public string? FreelancerId { get; set; }
        //public Freelancer Freelncer { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ReviewerId { get; set; } // ID of the client
        public string TargetUserId { get; set; } // ID of the freelancer
        public Rating Rating { get; set; }
    }
}
