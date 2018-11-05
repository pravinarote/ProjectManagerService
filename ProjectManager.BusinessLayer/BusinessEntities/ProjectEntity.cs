using System;

namespace ProjectManager.BusinessLayer.BusinessEntities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int Priority { get; set; }

        public DateTime? StartDate { get; set; }

        public int NoOfTasks { get; set; }

        public int NoOfCompletedTasks { get; set; }

        public DateTime? EndDate { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        //public UserEntity User { get; set; }
    }
}
