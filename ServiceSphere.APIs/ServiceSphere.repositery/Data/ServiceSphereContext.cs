using Microsoft.EntityFrameworkCore;
using ServiceSphere.core.Entities;
using ServiceSphere.core.Entities.Agreements;
using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Entities.Users.Freelancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.repositery.Data
{
    public class ServiceSphereContext:DbContext
    {
        public ServiceSphereContext(DbContextOptions<ServiceSphereContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet <Proposal> Proposals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet <Review> Reviews { get; set; }
     //   public DbSet<Post> Posts { get; set; }
        public DbSet<ProjectPosting> ProjectPostings { get; set; }
        public DbSet<ServicePosting> ServicePostings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public  DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
      //  public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Team> Teams { get; set; }
     //   public DbSet<ProjectSubCategory> ProjectSubCategory { get; set; }

    }
}
