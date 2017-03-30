using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentDataModel.DataModel
{
     public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public long UserId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [Index("User_UserName",IsUnique =true)]
        public string UserName { get; set; }
        [Index("User_Email",IsUnique = true)]
        [Column(TypeName="varchar")]
        [MaxLength(100)]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool Locked { get; set; }
        public DateTime DateOfAccountCreation { get; set; }
       
    }
}
