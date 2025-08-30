using Application.UseCases.WorkItems;
using Infra.Persistence.Json;
using Presentation.CLI.Controllers.WorkItems;

if (args.Length == 0)
{
  Console.WriteLine("Please insert some valid command (add, update, delete, mark-in-progress, mark-done, list)");

  return;
}

var command = args[0].ToLower();
var remainingArgs = args.Skip(1).ToArray();

string currentDirectory = Environment.CurrentDirectory;
string fileName = "tasks.json";
string filePath = Path.Combine(currentDirectory, fileName);

var workItemRepository = new JsonWorkItemRepository(filePath);

switch (command)
{
  case "add":
    {
      var addWorkItemController = new AddWorkItemController(new AddWorkItemUseCase(workItemRepository));

      await addWorkItemController.HandleAsync(remainingArgs);

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
    Console.WriteLine("Please insert some valid command (add, update, delete, mark-in-progress, mark-done, list)");
    break;
}

await workItemRepository.SaveWorkItemsToJsonAsync();