using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Todo_cs.TaskManager
{
  public class TaskItem
  {
    public string Name { get; set; } = "";
    private string dueDate { get; set; } = "";
    public bool Completed { get; set; } = false;

    public string DueDate
    {
      get => dueDate;
      set
      {
        string pattern = @"^\d{4}-(0?[1-9]|1[0-2])-(0?[1-9]|[12][0-9]|3[01])$";
        if (value != "")
        {
          bool IsMatch = Regex.IsMatch(value, pattern);
          if (!IsMatch) throw new Exception("Enter a valid date or leave empty");
        }
        dueDate = value;
      }
    }

    public TaskItem(string name, string dueDate)
    {
      Name = name;
      DueDate = dueDate;
    }

  }

  abstract public class Tasks
  {
    //A static method must be modifying a static value and A non-static method must be modifying a non-static value 
    public static List<TaskItem> tasks { get; set; } = new List<TaskItem>();
    //TaskItems ewTaskItems = new TaskItems("name", "dueDate");
    public static TaskItem AddTaskItem(TaskItem taskItem)
    {
      tasks.Add(taskItem);
      return taskItem;
    }
  }

}

