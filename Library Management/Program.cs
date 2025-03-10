using System;
using System.Collections.Generic;

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; } = false;
}

class Library
{
    private List<Book> books = new List<Book>();
    private int bookIdCounter = 1;

    public void AddBook(string title, string author)
    {
        books.Add(new Book { Id = bookIdCounter++, Title = title, Author = author });
        Console.WriteLine("\n✅ Book added successfully!\n");
    }

    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("\n📚 No books available in the library.\n");
            return;
        }

        Console.WriteLine("\n📖 Library Books:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("| ID  | Title                | Author          | Available |");
        Console.WriteLine("---------------------------------------------------");

        foreach (var book in books)
        {
            Console.WriteLine($"| {book.Id,-3} | {book.Title,-20} | {book.Author,-15} | {(book.IsBorrowed ? "No ❌" : "Yes ✅")}");
        }

        Console.WriteLine("---------------------------------------------------\n");
    }

    public void BorrowBook(int bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("\n❌ Book ID not found!\n");
        }
        else if (book.IsBorrowed)
        {
            Console.WriteLine("\n⚠️ Sorry, this book is already borrowed!\n");
        }
        else
        {
            book.IsBorrowed = true;
            Console.WriteLine("\n📕 Book borrowed successfully! Enjoy your reading. 😊\n");
        }
    }

    public void ReturnBook(int bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book == null)
        {
            Console.WriteLine("\n❌ Invalid book ID!\n");
        }
        else if (!book.IsBorrowed)
        {
            Console.WriteLine("\n⚠️ This book was never borrowed!\n");
        }
        else
        {
            book.IsBorrowed = false;
            Console.WriteLine("\n📗 Book returned successfully! Thank you!\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        while (true)
        {
            Console.WriteLine("\n📚 Library Management System");
            Console.WriteLine("1️⃣ Add Book");
            Console.WriteLine("2️⃣ Display Books");
            Console.WriteLine("3️⃣ Borrow Book");
            Console.WriteLine("4️⃣ Return Book");
            Console.WriteLine("5️⃣ Exit");
            Console.Write("➡️ Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\n❌ Invalid input! Please enter a number.\n");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("\n📖 Enter book title: ");
                    string title = Console.ReadLine().Trim();
                    Console.Write("✍ Enter author: ");
                    string author = Console.ReadLine().Trim();
                    library.AddBook(title, author);
                    break;

                case 2:
                    library.DisplayBooks();
                    break;

                case 3:
                    Console.Write("\n📕 Enter book ID to borrow: ");
                    if (int.TryParse(Console.ReadLine(), out int borrowId))
                        library.BorrowBook(borrowId);
                    else
                        Console.WriteLine("\n❌ Invalid ID! Please enter a valid number.\n");
                    break;

                case 4:
                    Console.Write("\n📗 Enter book ID to return: ");
                    if (int.TryParse(Console.ReadLine(), out int returnId))
                        library.ReturnBook(returnId);
                    else
                        Console.WriteLine("\n❌ Invalid ID! Please enter a valid number.\n");
                    break;

                case 5:
                    Console.WriteLine("\n👋 Thank you for using the Library System! Goodbye!\n");
                    return;

                default:
                    Console.WriteLine("\n❌ Invalid choice! Please enter a number between 1 and 5.\n");
                    break;
            }
        }
    }
}
