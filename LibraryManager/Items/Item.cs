namespace LibraryManager;

public abstract class Item
{
    public string Name { get; set; }
    public int Id { get; set; }
    public bool IsBorrowed { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}