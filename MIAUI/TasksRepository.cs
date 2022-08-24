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
        conn.CreateTable<Task>();
    }
    
    public TasksRepository(string dbPath)
    {
        _dbPath = dbPath;
    }
    public void AddNewTask(string taskName)
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

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, taskName);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", taskName, ex.Message);
        }
    }
}
