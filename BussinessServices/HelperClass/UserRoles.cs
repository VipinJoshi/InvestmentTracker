using System.Collections.Generic;

namespace BussinessServices.HelperClass
{
    public class UserRoles
    {
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
