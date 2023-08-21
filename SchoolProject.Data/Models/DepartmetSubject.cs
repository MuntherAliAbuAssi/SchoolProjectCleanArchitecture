using SchoolProject.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Models
{
    public class DepartmetSubject : GeneralLocalizableEntity
    {
        [Key]
        public int DeptSubID { get; set; }

        public int DID { get; set; }

        public int SubID { get; set; }

        [ForeignKey(nameof(DID))]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }

        [ForeignKey(nameof(SubID))]
        [InverseProperty("DepartmetsSubjects")]
        public virtual Subject? Subject { get; set; }
    }
}