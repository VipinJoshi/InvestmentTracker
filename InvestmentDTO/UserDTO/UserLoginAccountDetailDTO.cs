using System;

namespace InvestmentDTO.UserDTO
{
    public class UserLoginAccountDetailDTO
    {
        public long UserAccountDetailID { get; set; }
        public long UserId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PanCard { get; set; }
        public int? EarningSlabID { get; set; }
        public bool? Gender { get; set; }
        public string MobileNumber { get; set; }
        public virtual UserLoginDTO UserLogin { get; set; }
    }
}
