using SchoolProject.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Models
{
    public class Instractor : GeneralLocalizableEntity
    {
        public Instractor()
        {
            Instractors = new HashSet<Instractor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }

        public string? ENameAr { get; set; }

        public string? ENameEn { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }

        public int? SupervisorId { get; set; }

        public decimal? Salary { get; set; }

        public int DID { get; set; }

        [ForeignKey(nameof(DID))]
        [InverseProperty("Instractors")]
        public Department? department { get; set; }

        [InverseProperty("Instractor")]
        public Department? DepartmentManager { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instractors")]
        public Instractor? Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual ICollection<Instractor> Instractors { get; set; }

        [InverseProperty("Instractor")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
