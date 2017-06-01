using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentDataModel.DataModel
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        //foriegnKey for Login 
        public long UserId { get; set; }
        //foriegnKey for Role
        public int RoleId { get; set; }

        public virtual UserLogin UserLogin { get; set; }
        public Role Role { get; set; }
        public bool Active { get; set; }
    }
}
