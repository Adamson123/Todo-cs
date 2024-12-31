
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
      Tasks.WriteTasksToFile();
    }
    static void EditTaskItemDueDate()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to edit due date:"));
      int index = Utils.HandleIndexInput();
      Console.WriteLine(Utils.ChangeTextColor("Enter new due date:"));
      string dueDate = Console.ReadLine() ?? "";
      Tasks.tasks[index].DueDate = dueDate;
      Tasks.WriteTasksToFile();
    }
    static void EditTaskItemName()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to edit name:"));
      int index = Utils.HandleIndexInput();
      Console.WriteLine(Utils.ChangeTextColor("Enter task new name:"));
      string name = Console.ReadLine() ?? "";
      Tasks.tasks[index].Name = name;
      Tasks.WriteTasksToFile();
    }

    static void MarkAsComplete()
    {
      Console.WriteLine(Utils.ChangeTextColor("Enter task index to mark complete:"));
      int index = Utils.HandleIndexInput();
      // Tasks.EditTaskItemCompletion(index, true);
      Tasks.tasks[index].Completed = true;
      Tasks.WriteTasksToFile();
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
      Tasks.WriteTasksToFile();
    }


    static void LogMenu(string errMessage = "")
    {
      Console.Clear();
      Utils.TasksLogger(Tasks.tasks);
      string[] Options = {
      "Enter \"N\" to add a new task...",
      "Enter \"E\" to edit a task name...",
      "Enter \"D\" to edit a task date...",
      "Enter \"C\" to mark a task as completed...",
      "Enter \"I\" to mark a task as incompleted...",
      "Enter \"R\" to delete a task...",
      "Enter \"ESC\" to exit program...\n"
      };
      foreach (string option in Options)
      {
        Console.WriteLine(option);
      }
      Console.WriteLine(Utils.ChangeTextColor(errMessage, "31"));
    }

    static void HandleCommand(Action action)
    {
      LogMenu();
      string errMessage = Utils.HandleFuncError(action);
      LogMenu(errMessage);
    }

    static void Main(string[] args)
    {
      LogMenu();
      while (true)
      {
        var key = Console.ReadKey(intercept: true);
        if (key.Key == ConsoleKey.Escape)
        {
          Console.WriteLine("Exiting program...");
          break;
        }

        switch (key.Key)
        {
          case ConsoleKey.N:
            HandleCommand(CreateTaskItem);
            break;
          case ConsoleKey.E:
            HandleCommand(EditTaskItemName);
            break;
          case ConsoleKey.D:
            HandleCommand(EditTaskItemDueDate);
            break;
          case ConsoleKey.C:
            HandleCommand(MarkAsComplete);
            break;
          case ConsoleKey.I:
            HandleCommand(MarkAsInComplete);
            break;
          case ConsoleKey.R:
            HandleCommand(DeleteTaskItem);
            break;
        }
      }

    }
  }

}


