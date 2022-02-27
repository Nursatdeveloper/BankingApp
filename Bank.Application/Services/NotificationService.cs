using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Notification GenerateNotification(string notificationText, int userId)
        {
            Notification notification = new()
            {
                UserId = userId,
                NotificationText = notificationText,
                NotificationTime = DateTime.Now,
                IsSeen = false
            };
            return notification;
        }
    }
}
