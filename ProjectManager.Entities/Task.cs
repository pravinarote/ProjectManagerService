using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("tblTask")]
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [StringLength(50)]
        public string TaskName { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("ParentTaskId")]
        public ParentTask ParentTask { get; set; }
        [ForeignKey("ParentTask")]
        public int? ParentTaskId { get; set; }

        [ForeignKey("Id")]
        public TaskStatus TaskStatus { get; set; }
        [ForeignKey("TaskStatus")]
        public int? TaskStatusId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

    }
}
