using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; }

        public override void Execute()
        {
            Console.WriteLine($"Book '{BookReturned.Title}' returned by {Member.Name} on {TransactionDate}");
        }
    }
}
