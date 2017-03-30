using System.Collections.Generic;

namespace InvestmentTrackerApi.DTO
{
    public class UserAvailability
    {
        public bool UserNameAvailable { get; set; }
        public List<string> SuggestedUserName { get; set; }
    }
}