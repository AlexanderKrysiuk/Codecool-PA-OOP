using LibraryManager.Users;

namespace LibraryManager;

public class Library
{
    public List<Item> Items;
    public List<User> Users;

    public Library()
    {
        Items = new List<Item>();
        Users = new List<User>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void BorrowItem(Item item, User user)
    {
        if (user.LateReturns > 3)
        {
            Console.WriteLine("You are blocked for not returning items on time");
            return;
        }

        if (user.BorrowedItems.Count >= user.MaxItems)
        {
            Console.WriteLine("Please return borrowed items first, to borrow another item");
        }

        item.IsBorrowed = true;
        item.BorrowDate = DateTime.Now;
        user.BorrowedItems.Add(item);
    }

    public void ReturnItem(Item item, User user)
    {
        item.IsBorrowed = false;
        item.ReturnDate = DateTime.Now;
        user.BorrowedItems.Remove(item);
    }

    public List<(Item,User)> GetLateReturnItems()
    {
        DateTime current = DateTime.Now;
        List<(Item,User)> lateItems = new List<(Item,User)>();
        foreach (var user in Users)
        {
            foreach (var item in user.BorrowedItems)
            {
                if (item.IsBorrowed)
                {
                    TimeSpan difference = current - item.BorrowDate;

                    if (difference.TotalDays < 0)
                    {
                        lateItems.Add((item, user));
                    }
                }
            }
        }

        return lateItems;
    }
}