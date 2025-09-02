using Application.WorkItems.UseCases;
using Domain.Shared.Exceptions.App;
using Infra.Persistence.Json.WorkItems;
using Presentation.CLI.WorkItems.Controllers;

try
{
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
      {
        var updateWorkItemController = new UpdateWorkItemController(new UpdateWorkItemUseCase(workItemRepository));

        await updateWorkItemController.HandleAsync(remainingArgs);

        break;
      }
    case "delete":
      {
        var deleteWorkItemController = new DeleteWorkItemController(new DeleteWorkItemUseCase(workItemRepository));

        await deleteWorkItemController.HandleAsync(remainingArgs);

        break;
      }
    case "mark-in-progress":
      {
        var markWorkItemAsInProgressController = new MarkWorkItemAsInProgressController(new MarkWorkItemAsInProgressUseCase(workItemRepository));

        await markWorkItemAsInProgressController.HandleAsync(remainingArgs);

        break;
      }
    case "mark-done":
      {
        var markWorkItemAsDoneController = new MarkWorkItemAsDoneController(new MarkWorkItemAsDoneUseCase(workItemRepository));

        await markWorkItemAsDoneController.HandleAsync(remainingArgs);

        break;
      }
    case "list":
      {
        var listWorkItemsController = new ListWorkItemsController(new ListWorkItemsUseCase(workItemRepository));

        await listWorkItemsController.HandleAsync(remainingArgs);

        break;
      }
    default:
      Console.WriteLine("Please insert some valid command (add, update, delete, mark-in-progress, mark-done, list)");
      break;
  }

  await workItemRepository.SaveWorkItemsToJsonAsync();
}
catch (AppException ex)
{
  Console.Error.WriteLine($"Application error occurred: {ex.Message}");
}
catch (Exception)
{
  Console.Error.WriteLine($"An unexpected error occurred");
}
