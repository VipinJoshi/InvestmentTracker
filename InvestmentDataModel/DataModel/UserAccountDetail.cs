using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentDataModel.DataModel
{
    public class UserAccountDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public long UserAccountDetailID { get; set; }
        public long UserId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string PanCard { get; set; }
        public int? EarningSlabID { get; set; }
        public bool? Gender { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string MobileNumber { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
