using System;

namespace ProjectManager.BusinessLayer.BusinessEntities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ParentTaskName { get; set; }
        public int? ParentTaskId { get; set; }
        public bool IsTaskEnded { get; set; }

        public TaskStatusEntity TaskStatusEntity { get; set; }
        public int? TaskStatusId { get; set; }
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
