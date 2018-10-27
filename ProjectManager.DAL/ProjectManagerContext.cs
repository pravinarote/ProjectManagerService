using ProjectManager.Entities;
using System.Data.Entity;

namespace ProjectManager.DataLayer
{
    public class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext():base("ProjectManagerConn")
        {
            Database.SetInitializer(new ProjectManagerInitializer());
        }

        //public ProjectManagerContext(ProjectManagerInitializer init) : base("ProjectManagerConn")
        //{
        //    Database.SetInitializer(init);
        //}

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
