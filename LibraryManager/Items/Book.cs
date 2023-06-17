namespace LibraryManager;

public abstract class Book : Item
{
    public int Pages { get; set; }
    public BookType Type { get; set; }
}