using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models2
{
    [Table("AdjustBalance")]
    public class AdjustBalance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自增长
        [Key]
        [Column("RID")]
        public int RID { get; set; }

        //Decimal对应数据表中money类型
        [Column("Amount")]
        public Decimal Amount { get; set; }

        [Column("BeforeBalance")]
        public Decimal BeforeBalance { get; set; }

        [Column("AfterBalance")]
        public Decimal AfterBalance { get; set; }

        [ForeignKey("CardBCID")]
        public int CardBCID { get; set; }
        public int OperatorUID { get; set; }

        public string OperationLoginName { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationRemark { get; set; }

        //byte对应数据库表中tinyint类型
        [Column("AdjustType")]
        public byte AdjustType { get; set; }

        [Column("CompanyId")]
        public int? CompanyId { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
