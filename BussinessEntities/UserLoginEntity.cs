
using System;

namespace BussinessEntities
{
    public class UserLoginEntity
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool Locked { get; set; }
        public DateTime DateOfAccountCreation { get; set; }

    }
}
