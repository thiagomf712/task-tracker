using cli.src.entities;

if (args.Length == 0)
{
  Console.WriteLine("Please insert some valid command (add, update, delete, mark-in-progress, mark-done, list)");

  return;
}

var command = args[0].ToLower();

switch (command)
{
  case "add":
    {
      // Add task logic
      var description = args.Length > 1 ? args[1] : string.Empty;

      if (string.IsNullOrWhiteSpace(description))
      {
        Console.WriteLine("Description is required to add a new task.");
        return;
      }

      var workItem = WorkItem.Create(new() { Description = description });

      Console.WriteLine($"Task added = {workItem.Id} - {workItem.Description} [{workItem.Status}]");

      break;
    }
  case "update":
    // Update task logic
    break;
  case "delete":
    // Delete task logic
    break;
  case "mark-in-progress":
    // Mark task as in progress logic
    break;
  case "mark-done":
    // Mark task as done logic
    break;
  case "list":
    // List tasks logic
    break;
  default:
    Console.WriteLine("Unknown command");
    break;
}