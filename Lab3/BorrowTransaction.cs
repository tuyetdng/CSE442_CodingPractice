using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; }

        public override void Execute()
        {
            Console.WriteLine($"Book '{BookBorrowed.Title}' borrowed by {Member.Name} on {TransactionDate}");
        }
    }
}
