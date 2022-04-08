using Data.Model.BlogModule;
using Data.Model.CourseModule;
using Data.Model.EventModule;
using Data.Model.JobModule;
using Data.Model.UserModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUnit> CourseUnits { get; set; }
        public DbSet<CourseMaterial> CourseMaterials { get; set; }
    }
}
