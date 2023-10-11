namespace infrastructure;

public class Box
{
    public int Id { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Volume { get; set; }
    public string Material { get; set; }
    public int InventoryCount { get; set; }
    public double Price { get; set; }
    public string Name { get; set; }
}

public class PasswordHash
{
    public int UserId { get; set; }
    public byte[] Hash { get; set; }
    public byte[] Salt { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}