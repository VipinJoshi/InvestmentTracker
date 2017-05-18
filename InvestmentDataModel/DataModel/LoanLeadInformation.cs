/*
 * this is for lead creation
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentDataModel.DataModel
{
    public class LoanLeadInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadId { get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(250)]
        public string LeadDescription { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string EmailId { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string MobileNumber { get; set; }
        public DateTime? DateOfLeadCreation { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        //[ForeignKey("LoanTypeId")]
        public virtual LoanType LoanType { get; set; }

       
        public int LoanTypeId { get; set; }

    }
}
