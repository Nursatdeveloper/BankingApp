using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IIN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Notification> Notifications { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
