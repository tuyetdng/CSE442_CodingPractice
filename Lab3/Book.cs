using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Book : IPrintable
    {
        private int _year;
        private int _copiesAvailable;
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year
        {
            get => _year;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Year), "Year cannot be less than 0.");
                }
                _year = value;
            }
        }
        public string ISBN { get; set; }
        public int CopiesAvailable
        {
            get => _copiesAvailable;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(CopiesAvailable), "CopiesAvailable cannot be less than 0.");
                }
                _copiesAvailable = value;
            }
        }


        public Book(string title, string author, int year, string isbn, int copiesAvailable)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
            CopiesAvailable = copiesAvailable;
        }

        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
            Year = 0;
            ISBN = "N/A";
            CopiesAvailable = 0;
        }

        public string DisplayInfo()
        {
            return $"Title: {Title}\nAuthor: {Author}\nYear: {Year}\nISBN: {ISBN}\nCopies Available: {CopiesAvailable}";
        }

        public void PrintDeitails()
        {
            Console.WriteLine(DisplayInfo());
        }

    }
}
