
using Todo_cs.TaskManager;
using Todo_cs.Utilities;

namespace Todo_cs
{

  class Program
  {

    //Create a new task
    static void CreateTaskItem()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task name"));
      string name = Console.ReadLine() ?? "";
      Console.WriteLine(Utils.ChangeTextColor("Enter task date in format \"Year-Month-Day\" e.g.(2024-06-02)"));
      string dueDate = Console.ReadLine() ?? "";
      TaskItem newTask = new TaskItem(name, dueDate);
      Tasks.AddTaskItem(newTask);
    }
    static void EditTaskItemDueDate()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to edit due date:"));
      int index = Utils.HandleIndexInput();
      Console.WriteLine(Utils.ChangeTextColor("Enter new due date:"));
      string dueDate = Console.ReadLine() ?? "";
      Tasks.tasks[index].DueDate = dueDate;
    }
    static void EditTaskItemName()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to edit name:"));
      int index = Utils.HandleIndexInput();
      Console.WriteLine(Utils.ChangeTextColor("Enter task new name:"));
      string name = Console.ReadLine() ?? "";
      Tasks.tasks[index].Name = name;
    }

    static void MarkAsComplete()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to mark complete:"));
      int index = Utils.HandleIndexInput();
      // Tasks.EditTaskItemCompletion(index, true);
      Tasks.tasks[index].Completed = true;
    }

    static void MarkAsInComplete()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to mark incomplete:"));
      int index = Utils.HandleIndexInput();
      Tasks.tasks[index].Completed = false;
    }
    static void DeleteTaskItem()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to delete:"));
      int index = Utils.HandleIndexInput();
      Tasks.tasks.RemoveRange(index, 1);
    }


    static void LogMenu(string errMessage = "")
    {
      Console.Clear();
      Utils.TasksLogger(Tasks.tasks);
      Console.WriteLine("Enter \"N\" to add a new task...");
      Console.WriteLine("Enter \"E\" to edit a task name...");
      Console.WriteLine("Enter \"D\" to edit a task date...");
      Console.WriteLine("Enter \"C\" to mark a task as completed...");
      Console.WriteLine("Enter \"I\" to mark a task as incompleted...");
      Console.WriteLine("Enter \"R\" to delete a task...");
      Console.WriteLine("Enter \"ESC\" to exit program...\n");
      Console.WriteLine(Utils.ChangeTextColor(errMessage, "31"));
    }

    static void Main(string[] args)
    {
      LogMenu();
      // bool menuMode = true;
      while (true)
      {
        // LogMenu();
        // if (!menuMode) continue;
        var key = Console.ReadKey(intercept: true);
        if (key.Key == ConsoleKey.Escape)
        {
          Console.WriteLine("Exiting program...");
          break;
        }
        if (key.Key == ConsoleKey.N)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(CreateTaskItem);
          LogMenu(errMessage);
        }
        if (key.Key == ConsoleKey.E)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(EditTaskItemName);
          LogMenu(errMessage);
        }
        if (key.Key == ConsoleKey.D)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(EditTaskItemDueDate);
          LogMenu(errMessage);
        }
        if (key.Key == ConsoleKey.C)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(MarkAsComplete);
          LogMenu(errMessage);
        }
        if (key.Key == ConsoleKey.I)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(MarkAsInComplete);
          LogMenu(errMessage);
        }
        if (key.Key == ConsoleKey.R)
        {
          LogMenu();
          string errMessage = Utils.FuncWrapper(DeleteTaskItem);
          LogMenu(errMessage);
        }
      }

    }
  }

}


