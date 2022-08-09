using SQLite;

namespace MIAUI.Model;

[Table("user")]
public class User
{
    [PrimaryKey, AutoIncrement, Column("_id") ]
    public int Id { get; set; }

    [MaxLength(10), Unique]
    public string Name { get; set; }

    [MaxLength(16), Unique]
    public string Email { get; set; }
}
