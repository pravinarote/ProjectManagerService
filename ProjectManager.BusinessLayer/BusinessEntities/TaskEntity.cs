using System;

namespace ProjectManager.BusinessLayer.BusinessEntities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ParentTask { get; set; }
        public int? ParentTaskId { get; set; }
        public bool IsTaskEnded { get; set; }

        public TaskStatusEntity TaskStatusEntity { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
