namespace Lab3
{
    class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public Library(string libraryName, List<Book> books, List<Member> members)
        {
            LibraryName = libraryName;
            Books = books;
            Members = members;
        }

        public Library()
        {
            LibraryName = "Default Library";
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public Library(Library existingLibrary)
        {
            LibraryName = existingLibrary.LibraryName;
            Books = new List<Book>(existingLibrary.Books.Select(book => new Book(book.Title, book.Author, book.Year, book.ISBN, book.CopiesAvailable)));
            Members = new List<Member>(existingLibrary.Members.Select(member => new Member(member.MemberId, member.Name, member.Email)));
        }

        public void DisplayLibraryInfo()
        {
            Console.WriteLine("Library Name: " + LibraryName);

            Console.WriteLine("List Books: ");
            foreach (Book book in Books)
            {
                Console.WriteLine(book.DisplayInfo());
            }


            Console.WriteLine("List Member: ");
            foreach (Member members in Members)
            {
                Console.WriteLine(members.DisplayInfo());
            }
        }

        public event Action<Book, Member> OnBookBorrowed;

    }
}
