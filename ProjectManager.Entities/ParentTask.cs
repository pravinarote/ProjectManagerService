using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("tblParentTask")]
    public class ParentTask
    {
        [Key]
        [Required]
        public int ParentTaskId { get; set; }

        [StringLength(50)]
        public string ParentTaskName { get; set; }
    }
}
