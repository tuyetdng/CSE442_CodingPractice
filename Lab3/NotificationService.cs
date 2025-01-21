using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class NotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Notification sent: {message}");
        }

        public void SendNotification(string message, string recipient)
        {
            Console.WriteLine($"Notification sent to {recipient}: {message}");
        }

        public void SendNotification(string message, List<string> recipients)
        {
            foreach (var recipient in recipients)
            {
                Console.WriteLine($"Notification sent to {recipient}: {message}");
            }
        }
        public void SendNotification(Book book, Member member)
        {
            Console.WriteLine($"Notification: '{book.Title}' has been borrowed by {member.Name}.");
        }

        public void LogBorrowing(Book book, Member member)
        {
            Console.WriteLine($"Log: '{book.Title}' was borrowed by {member.Name} on {DateTime.Now}.");
        }

        public void Subscribe(Library library)
        {
            library.OnBookBorrowed += SendNotification;
            library.OnBookBorrowed += LogBorrowing;
        }
    }
}
