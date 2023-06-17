using LibraryManager.Users;

namespace LibraryManager;

public class Library
{
    private List<Item> Items;
    private List<User> Users;

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

    public void ReturnDate(Item item, User user)
    {
        item.IsBorrowed = false;
        item.ReturnDate = DateTime.Now;
        user.BorrowedItems.Remove(item);
    }

    public Item GetLateReturnItems()
    {
        DateTime current = DateTime.Now;
        Item lateItem = null;
        TimeSpan maxTime = TimeSpan.MinValue;

        foreach (var item in Items)
        {
            if (item.IsBorrowed)
            {
                TimeSpan time = current - item.BorrowDate;
                if (time > maxTime)
                {
                    maxTime = time;
                    lateItem = item;
                }
            }
        }

        return lateItem;
    }
}