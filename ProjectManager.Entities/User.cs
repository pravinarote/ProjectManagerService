using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmployeeId { get; set; }

        //[ForeignKey("ProjectId")]
        //public Project Project { get; set; }
        //[ForeignKey("Project")]
        //public int? ProjectId { get; set; }

        //[ForeignKey("TaskId")]
        //public Task Task { get; set; }
        //[ForeignKey("Task")]
        //public int? TaskId { get; set; }
    }
}
