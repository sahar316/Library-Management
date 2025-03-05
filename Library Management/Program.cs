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
        Console.WriteLine("Book added successfully!");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\nLibrary Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Available: {!book.IsBorrowed}");
        }
    }

    public void BorrowBook(int bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book != null && !book.IsBorrowed)
        {
            book.IsBorrowed = true;
            Console.WriteLine("Book borrowed successfully!");
        }
        else
        {
            Console.WriteLine("Book not available!");
        }
    }

    public void ReturnBook(int bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book != null && book.IsBorrowed)
        {
            book.IsBorrowed = false;
            Console.WriteLine("Book returned successfully!");
        }
        else
        {
            Console.WriteLine("Invalid book ID or book is not borrowed!");
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
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Display Books");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    library.AddBook(title, author);
                    break;
                case 2:
                    library.DisplayBooks();
                    break;
                case 3:
                    Console.Write("Enter book ID to borrow: ");
                    if (int.TryParse(Console.ReadLine(), out int borrowId))
                        library.BorrowBook(borrowId);
                    else
                        Console.WriteLine("Invalid ID!");
                    break;
                case 4:
                    Console.Write("Enter book ID to return: ");
                    if (int.TryParse(Console.ReadLine(), out int returnId))
                        library.ReturnBook(returnId);
                    else
                        Console.WriteLine("Invalid ID!");
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }
    }
}
