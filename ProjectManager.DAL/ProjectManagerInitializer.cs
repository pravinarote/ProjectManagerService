using ProjectManager.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProjectManager.DataLayer
{
    public class ProjectManagerInitializer : DropCreateDatabaseIfModelChanges<ProjectManagerContext>
    {
        protected override void Seed(ProjectManagerContext context)
        {
            IList<TaskStatus> taskStatuses = new List<TaskStatus>();

            taskStatuses.Add(new TaskStatus() { Name = "Task Created" });
            taskStatuses.Add(new TaskStatus() { Name = "Task Completed" });

            context.TaskStatuses.AddRange(taskStatuses);
            
            base.Seed(context);
        }
    }
}
