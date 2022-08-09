using MIAUI.Model;
using SQLite;

namespace MIAUI;
public class UserRepository
{
    string _dbPath;
    private SQLiteConnection conn;
    public string StatusMessage { get; set; }

    public UserRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    // connect to the database
    private void Init()
    {
        if (conn is not null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<User>();
    }

    public void AddNewPerson(string name, string email)
    {
        int result = 0;
        try
        {
            Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            result = conn.Insert(new User { Name = name, Email = email });

            // TODO: Insert the new person into the database
            result = 0;

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }

    public List<User> GetAllPeople()
    {
        try
        {
            Init();
            return conn.Table<User>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<User>();
    }

    public User getUserById(int id)
    {
        var user = conn.Table<User>()
                       .Where(x => x.Id == id)
                       .FirstOrDefault();
        return user;
    }

}
