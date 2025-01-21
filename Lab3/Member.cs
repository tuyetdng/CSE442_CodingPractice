using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Member : IPrintable, IMemberActions
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(int memberId, string name, string email)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
        }
        public Member() { 
        
        }

        public string DisplayInfo()
        {
            return $"Member ID: {MemberId}\nName: {Name}\nEmail: {Email}";
        }

        public void PrintDeitails()
        {
            Console.WriteLine(DisplayInfo());
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
