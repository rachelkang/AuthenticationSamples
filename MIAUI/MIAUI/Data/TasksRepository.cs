﻿namespace MIAUI.Data;

public class TasksRepository
{
    string _dbPath;
    public string StatusMessage { get; set; }

    private SQLiteConnection conn;

    private void Init ()
    {
        if (conn is not null)
            return;

        conn = new SQLiteConnection (_dbPath);
        conn.CreateTable<Model.Task> ();
    }

    public TasksRepository (string dbPath)
    {
        _dbPath = dbPath;
    }
    public async void AddNewTask (string taskName)
    {
        try
        {
            Init ();
            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty (taskName))
                throw new Exception ("Valid name required");

            conn.Insert (new Model.Task(taskName));

            Console.WriteLine(string.Format("{0} record(s) added (Name: {1})", result, taskName));
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Failed to add {0}. Error: {1}", taskName, ex.Message));
        }
    }

    public int UpdateDetails (Model.Task task)
    {
        return conn.Update (task);
    }

    public int DeleteTask (int id)
    {
        return conn.Delete<Model.Task> (id);
    }

    public List<Model.Task> GetAllTasks ()
    {
        try
        {
            Init ();
            return conn.Table<Model.Task>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Model.Task> ();
    }
}
