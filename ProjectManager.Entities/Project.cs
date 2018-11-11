using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("tblProject")]
    public class Project
    {
        [Key]
        [Required]
        public int ProjectId { get; set; }

        [StringLength(50)]
        public string ProjectName { get; set; }

        [Required]
        public int Priority { get; set; }

        
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }

        public bool IsSuspended { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
