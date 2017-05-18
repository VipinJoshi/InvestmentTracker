using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentDataModel.DataModel
{
    public class LoanType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanTypeId { get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(25)]
        public string LoanTypeName { get; set; } 
        public bool Active { get; set; }


    }
}
