namespace Building.DataModel;

public class User : UserBase
{
    public required String FirstName { get; set; }

    public required String LastName { get; set; }

    public String? MiddleName { get; set; }

    public required Region Region { get; set; }

    public required String PhoneNumber { get; set; }
}
