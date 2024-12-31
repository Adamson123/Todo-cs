using Todo_cs.TaskManager;
namespace Todo_cs.Utilities
{
  public static class Utils
  {
    public static string FuncWrapper(Action action)
    {
      try
      {
        action();
        return "";
      }
      catch (Exception error)
      {
        return error.Message;
      }
    }

    public static string ChangeTextColor(string text, string start = "33")
    {
      return $"\u001b[{start}m{text}\u001b[0m";
    }

    public static int HandleIndexInput()
    {
      int index;
      bool result = int.TryParse(Console.ReadLine(), out index);
      if (!result) throw new Exception("Invalid input!");
      if (index > Tasks.tasks.Count - 1) throw new Exception("Task does not exist!");
      return index;
    }


    static void DrawLine()
    {
      for (int i = 0; i < minSpace * 4 + 13; i++)
      {
        Console.Write("-");
      }
      Console.WriteLine("");
    }

    static int minSpace = 12;
    public static void TasksLogger(List<TaskItem> tasks)
    {

      if (tasks.Count > 0)
        foreach (TaskItem taskItem in tasks)
        {
          if (taskItem.DueDate.Length > minSpace)
            minSpace = taskItem.DueDate.Length + 2;
          if (taskItem.Name.Length > minSpace)
            minSpace = taskItem.Name.Length + 2;
        }
      else
        minSpace = 13;

      DrawLine();
      // Use Console.WriteLine and String.Format or just the format string directly 
      Console.WriteLine("| {0," + -minSpace + "} | {1," + -minSpace + "} | {2," + -minSpace + "} | {3," + -minSpace + "} |", "Index", "Name", "Due date", "Status");
      DrawLine();

      int counter = 0;
      if (tasks.Count > 0)

        foreach (TaskItem taskItem in tasks)
        {
          string statusCoat = taskItem.Completed ? Utils.ChangeTextColor("{3," + -minSpace + "}", "32") : Utils.ChangeTextColor("{3," + -minSpace + "}", "31");
          string status = taskItem.Completed ? "Completed" : "InComplete";
          Console.WriteLine("| {0," + -minSpace + "} | {1," + -minSpace + "} | {2," + -minSpace + "} | " + statusCoat + " |", counter, taskItem.Name, taskItem.DueDate, status);
          counter++;
        }
      else
        Console.WriteLine("|                       No tasks were found                     |");
      DrawLine();
      Console.WriteLine("\n");
    }
  }
}
