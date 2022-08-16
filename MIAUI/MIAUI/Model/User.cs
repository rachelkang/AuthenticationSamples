using SQLite;

namespace MIAUI.Model;

[Table("users")]
public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    //public ObservableCollection<Task> Tasks { get; set; }

}
