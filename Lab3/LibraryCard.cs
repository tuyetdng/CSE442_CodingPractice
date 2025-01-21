using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class LibraryCard
    {
        public string CardNumber { get; }

        public Member Owner { get; set; }

        private DateTime _issueDate;
        public DateTime IssueDate
        {
            get { return _issueDate; }
            private set { _issueDate = value; }
        }

        public LibraryCard(string cardNumber, Member owner, DateTime issueDate)
        {
            CardNumber = cardNumber;
            Owner = owner;
            IssueDate = issueDate;
        }

        public string RenewCard()
        {
            IssueDate = DateTime.Now;
            return ($"Library card {CardNumber} renewed. New issue date: {IssueDate}");
        }

        public string DisplayInfo()
        {
            return $"Card number: {CardNumber}\nOwner: {Owner.Name}\nIssue date: {IssueDate}";
        }
    }
}
