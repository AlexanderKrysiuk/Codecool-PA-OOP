// See https://aka.ms/new-console-template for more information

//New Library

using LibraryManager;
using LibraryManager.Users;

Library library = new Library();

// Adding some items
Book book1 = new Book { Name = "W Pustyni i W Puszczy", Id = 1, Pages = 200, Type = BookType.Novel };
Book book2 = new Book { Name = "Wędrówka Dusz", Id = 2, Pages = 300, Type = BookType.TextBook };
DVD dvd1 = new DVD { Name = "Hobbyte", Id = 3, Title = "Hobbyte" };
DVD dvd2 = new DVD { Name = "Świt Żywych Programistów", Id = 4, Title = "Świt Żywych Programistów" };

//Adding items to library item list
library.AddItem(book1);
library.AddItem(book2);
library.AddItem(dvd1);
library.AddItem(dvd2);

// Adding Users
Resident resident1 = new Resident { Name = "Sławek", Id = 1001, LateReturns = 0 };
Resident resident2 = new Resident { Name = "Kasia", Id = 1002, LateReturns = 3 };
Student student1 = new Student { Name = "Alex", Id = 2001, LateReturns = 1 };
Student student2 = new Student { Name = "Karolina", Id = 2002, LateReturns = 0 };

// Adding users to library user list
library.AddUser(resident1);
library.AddUser(resident2);
library.AddUser(student1);
library.AddUser(student2);

// Borrow items
library.BorrowItem(dvd1, resident1);
library.BorrowItem(book1, resident1);
library.BorrowItem(book2, resident2);
library.BorrowItem(dvd2, student1);
library.BorrowItem(dvd2, student2);
library.BorrowItem(book1, student2);

// Return items
library.ReturnItem(dvd1, resident1);
library.ReturnItem(book1, resident1);

// Display Results
Console.WriteLine("Welcome to Library Manager System");
Console.WriteLine("\nItems in library:");
foreach (var item in library.Items)
{
    Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}, Borrowed: {item.IsBorrowed}");
}

Console.WriteLine("\nUsers in the library:");
foreach (var user in library.Users)
{
    Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Late Returns: {user.LateReturns}");
}

Console.WriteLine("\nBurrowed Items:");
foreach (var user in library.Users)
{
    Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}");
    {
        foreach (var item in user.BorrowedItems)
        {
            Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}");
        }

        Console.WriteLine();
    }
}

// Get late items
List<(Item,User)> lateItems = library.GetLateReturnItems();

// Display late items
Console.WriteLine("\nlate items:");
foreach (var (item,user) in lateItems)
{
    Console.WriteLine($"Item ID: {item.Id}, Item Name: {item.Name}, User ID: {user.Id}, User Name: {user.Name}");
}

List<Item> overdueItems = library.GetLateItems();

List<Item> mostOverdueItems = overdueItems
    .Where(item => item.IsBorrowed)
    .OrderByDescending(item => (DateTime.Now - item.BorrowDate).TotalDays)
    .Take(3)
    .ToList();

// Display the three most overdue items
Console.WriteLine("\nThree Most Overdue Items:");
foreach (var item in mostOverdueItems)
{
    TimeSpan overdueTime = DateTime.Now - item.BorrowDate;
    Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}, Overdue Days: {overdueTime.Days}");
}

List<(Item,User)> ShameList = library.GetLateReturnItems()
    .OrderByDescending(item => (DateTime.Now - item.BorrowDate).TotalDays)
    .Take(3)
    .ToList();