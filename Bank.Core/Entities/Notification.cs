using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string NotificationText { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool IsSeen { get; set; }
    }
}
