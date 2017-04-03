using System.Collections.Generic;

namespace InvestmentTrackerDTO
{
    public class UserAvailability
    {
        public bool UserNameAvailable { get; set; }
        public List<string> SuggestedUserName { get; set; }
    }
}
