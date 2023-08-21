using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Models
{
    public class Ins_Subject
    {
        [Key]
        public int InsSubId { get; set; }
        public int SubID { get; set; }
        public int InsId { get; set; }
        [ForeignKey(nameof(InsId))]
        [InverseProperty("Ins_Subjects")]
        public Instractor? Instractor { get; set; }
        [ForeignKey(nameof(SubID))]
        [InverseProperty("Ins_Subjects")]
        public Subject? Subject { get; set; }

    }
}
