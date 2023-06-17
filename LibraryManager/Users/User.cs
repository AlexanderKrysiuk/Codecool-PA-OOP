namespace LibraryManager.Users;

public abstract class User
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int LateReturns { get; set; }
    public List<Item> BorrowedItems { get; set; }

    public abstract int MaxItems { get; }
    public abstract int MaxDays { get; }
    protected User()
    {
        BorrowedItems = new List<Item>();
    }
}