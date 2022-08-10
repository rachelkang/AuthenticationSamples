using SQLite;
using MIAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIAUI;

public class TasksRepository
{
    string _dbPath;
    public string StatusMessage { get; set; }

    private SQLiteConnection conn;
    
    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Model.Task>();
    }
    
    public TasksRepository(string dbPath)
    {
        _dbPath = dbPath;
    }
    public async void AddNewTask(string taskName)
    {
        int result = 0;
        try
        {
            Init();
            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(taskName))
                throw new Exception("Valid name required");

            result = conn.Insert(new Model.Task(taskName));
            result = 0;

            Console.WriteLine(string.Format("{0} record(s) added (Name: {1})", result, taskName));
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Failed to add {0}. Error: {1}", taskName, ex.Message));
        }
    }

    public int UpdateDetails(Model.Task task)
    {
        int result = 0;
        result = conn.Update(task);
        return result;
    }

    public int DeleteTask(int id)
    {
        int result = 0;
        result = conn.Delete<Model.Task>(id);
        return result;
    }

    public List<Model.Task> GetAllTasks()
    {
        try
        {
            Init();
            return conn.Table<Model.Task>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Model.Task>();
    }
}
