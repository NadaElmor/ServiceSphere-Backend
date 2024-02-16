using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Entities.Services
{
    public class Service:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        //foreign key for freelancer
        public string? FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        //foreign key for Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
