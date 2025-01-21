namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            Console.WriteLine("Exercise 1");
            Book book = new Book("The Test", "A.B.B Newton", 1909, "111-0-111-111-1", 5);
            Console.WriteLine(book.DisplayInfo());

            Console.WriteLine("Exercise 2");
            Member member = new Member(1, "John Doe", "efh@gmail.com");
            //Console.WriteLine(member.DisplayInfo());

            PremiumMember premiumMember = new PremiumMember(2, "Jane Doe", "dsfd@gmail.com", DateTime.Now, 5);
            //Console.WriteLine(premiumMember.DisplayInfo());

            Console.WriteLine("Exercise 3, 4");
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new BorrowTransaction { TransactionId = "1", TransactionDate = DateTime.Now, Member = member, BookBorrowed = book });
            transactions.Add(new BorrowTransaction { TransactionId = "2", TransactionDate = DateTime.Now, Member = premiumMember, BookBorrowed = book });
            transactions.Add(new ReturnTransaction { TransactionId = "3", TransactionDate = DateTime.Now, Member = member, BookReturned = book });
            transactions.Add(new ReturnTransaction { TransactionId = "4", TransactionDate = DateTime.Now, Member = premiumMember, BookReturned = book });

            foreach (Transaction transaction in transactions)
            {
                transaction.Execute();
            }

            Console.WriteLine("Exercise 5");
            PremiumMember premiumMember2 = new PremiumMember(3, "Juchi Hayato", "bdg@gmail.com", DateTime.Now, 5);
            premiumMember2.BorrowBook(book);

            Console.WriteLine("Exercise 6");
            Console.WriteLine("Default: ");
            Library libraryDefault = new Library();
            libraryDefault.DisplayLibraryInfo();


            Console.WriteLine("Full arguments: ");
            List<Book> books = new List<Book>();
            books.Add(new Book("The Test", "A.B.B Newton", 1909, "111-0-111-111-1", 5));
            books.Add(new Book("The Test 2", "A.B.B Newton", 1909, "111-0-111-111-1", 5));
            books.Add(new Book("The Test 3", "A.B.B Newton", 1909, "111-0-111-111-1", 5));

            List<Member> members = new List<Member>();
            members.Add(new Member(1, "ABC", "abc@gmail.com"));
            members.Add(new Member(2, "DEF", "def@gmail.com"));
            members.Add(new Member(3, "GHI", "ghi@gmail.com"));

            Library libraryFullArgument = new Library("My First Library", books, members);
            libraryFullArgument.DisplayLibraryInfo();

            Console.WriteLine("Copy: ");
            Library libraryCopy = new Library(libraryFullArgument);
            libraryCopy.DisplayLibraryInfo();

            Console.WriteLine("Exercise 7");
            NotificationService notificationService = new NotificationService();
            notificationService.SendNotification("Hello World");

            AdvancedNotificationService advancedNotificationService = new AdvancedNotificationService();
            advancedNotificationService.SendNotification("Hello World 2");

            Console.WriteLine("Exercise 8");
            LibraryCard libraryCard = new LibraryCard("ID001", member, new DateTime(2015, 12, 25));
            Console.WriteLine("Before Renew: ");
            Console.WriteLine(libraryCard.DisplayInfo());
            libraryCard.RenewCard();
            Console.WriteLine("After Renew: ");
            Console.WriteLine(libraryCard.DisplayInfo());

            Console.WriteLine("Exercise 9");
            BookClass bookClass = new BookClass("AB20", "Hello", "JackTheRipper");
            BookRecord bookRecord = new BookRecord("AB20", "Hello", "JackTheRipper");

            if (bookClass.Equals(bookRecord))
            {
                Console.WriteLine("They are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }

            Console.WriteLine("Exercise 10");
            Library library = new Library("My First Library", books, members);
            notificationService.Subscribe(library);
        }
    }
}
