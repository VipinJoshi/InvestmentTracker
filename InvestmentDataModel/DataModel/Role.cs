using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentDataModel.DataModel
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(25)]
        public string RoleName { get; set; }
        public bool Active { get; set; }
    }
}
