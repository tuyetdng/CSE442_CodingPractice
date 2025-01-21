using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class PremiumMember : Member, IMemberActions
    {
        public DateTime MembershipExpiry { get; set; }
        public int MaxBooksAllowed { get; set; }   
        public PremiumMember(int memberId, string name, string email, DateTime membershipExpiry, int maxBooksAllowed) : base(memberId, name, email)
        {
            MembershipExpiry = membershipExpiry;
            MaxBooksAllowed = maxBooksAllowed;
        }
        public PremiumMember() { }

        public string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nMembership Expiry: {MembershipExpiry}\nMax Books Allowed: {MaxBooksAllowed}";
        }
        public void BorrowBook(Book book)
        {
            Console.WriteLine($"Book '{book.Title}' borrowed by {Name}");
        }

        public void ReturnBook(Book book)
        {
            Console.WriteLine($"Book '{book.Title}' returned by {Name}");
        }
    }
}
