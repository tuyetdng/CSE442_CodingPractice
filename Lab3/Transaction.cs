using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Transaction
    {
        public  string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Member Member { get; set; }

        public abstract void Execute();
    }

}
