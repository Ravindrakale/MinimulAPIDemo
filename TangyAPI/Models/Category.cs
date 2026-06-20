namespace TangyAPI.Models;

public class Category
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public DateTime AddedOn { get; set; }
}
