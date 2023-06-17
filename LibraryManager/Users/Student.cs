namespace LibraryManager.Users;

public class Student : User
{
    public override int MaxItems => 5;
    public override int MaxDays => 14;
}