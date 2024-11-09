using System;
using System.Collections;

//namespace Program
//{
//    class Book : IComparable, ICloneable
//    {
//        string name;
//        string author;

//        public Book(string name, string author)
//        {
//            this.name = name;
//            this.author = author;
//        }

//        public Book() : this("2 Воробья", "Степан") { }

//        public void Show()
//        {
//            Console.WriteLine("\n{0}   {1}", name, author);
//        }

//        public object Clone()
//        {
//            return new Book(this.name, this.author);
//        }

//        public int CompareTo(object obj)
//        {
//            if (obj is Book book)
//                return name.CompareTo(book.name);

//            throw new ArgumentException("Object is not a Book");
//        }

//        public class SortByName : IComparer
//        {
//            public int Compare(object obj1, object obj2)
//            {
//                if (obj1 is Book book1 && obj2 is Book book2)
//                    return book1.name.CompareTo(book2.name);

//                throw new ArgumentException("One or both objects are not Books");
//            }
//        }

//        public class SortByAuthor : IComparer
//        {
//            public int Compare(object obj1, object obj2)
//            {
//                if (obj1 is Book book1 && obj2 is Book book2)
//                    return book1.author.CompareTo(book2.author);

//                throw new ArgumentException("One or both objects are not Books");
//            }
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Book[] c = new Book[4];
//            c[0] = new Book("Граф Монте-Кристо", "Александр Дюма");
//            c[1] = new Book("Преступление и наказание", "Достоевский");
//            c[2] = new Book("Портрет", "Иванченко");
//            c[3] = new Book("Война и мир", "Толстой");

//            Console.WriteLine("-----------------:");
//            foreach (Book temp in c)
//                temp.Show();

//            Array.Sort(c);
//            Console.WriteLine("\n++ - +++ - ++:");
//            foreach (Book temp in c)
//                temp.Show();

//            Array.Sort(c, new Book.SortByName());
//            Console.WriteLine("\nНазвание:");
//            foreach (Book temp in c)
//                temp.Show();

//            Array.Sort(c, new Book.SortByAuthor());
//            Console.WriteLine("\nАвтор:");
//            foreach (Book temp in c)
//                temp.Show();

//            Book originalBook = new Book("Вернись", "Андрей");
//            Console.WriteLine("\nОригинал:");
//            originalBook.Show();

//            Book clonedBook = (Book)originalBook.Clone();
//            Console.WriteLine("\nICloneable:");
//            clonedBook.Show();
//        }
//    }
//}


namespace Boook
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public Book(string name, string author)
        {
            this.Name = name;
            this.Author = author;
        }

        public void Show()
        {
            Console.WriteLine("{0} - {1}", Name, Author);
        }
    }

    class Library : IEnumerable<Book>
    {
        private Book[] books;

        public Library(Book[] booksArray)
        {
            this.books = booksArray;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("Граф Монте-Кристо", "Александр Дюма"),
                new Book("Преступление и наказание", "Достоевский"),
                new Book("Портрет", "Иванченко"),
                new Book("Война и мир", "Толстой")
            };

            Library library = new Library(books);
            Console.WriteLine("Книги :");
            foreach (Book book in library)
            {
                book.Show();
            }
        }
    }
}
