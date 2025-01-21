using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class AdvancedNotificationService : NotificationService
    {
        public void SendNotification(string message)
        {
            string timestampedMessage = $"[{DateTime.Now}] {message}";
            base.SendNotification(timestampedMessage);
        }
    }
}
