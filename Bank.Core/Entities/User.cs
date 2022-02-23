using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IIN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
