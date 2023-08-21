using SchoolProject.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Models
{
    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instractors = new HashSet<Instractor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }

        [StringLength(500)]
        public string? DNameAr { get; set; }

        [StringLength(200)]
        public string? DNameEn { get; set; }

        public int? InsManager { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty("department")]
        public virtual ICollection<Instractor> Instractors { get; set; }

        [ForeignKey("InsManager")]
        [InverseProperty("DepartmentManager")]
        public virtual Instractor? Instractor { get; set; }

    }
}