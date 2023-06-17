namespace LibraryManager.Users;

public class Resident : User
{
  public override int MaxItems => 3;
  public override int MaxDays => 7;
}