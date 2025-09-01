using Application.WorkItems.UseCases;

namespace Presentation.CLI.WorkItems.Controllers;

public class AddWorkItemController(AddWorkItemUseCase addWorkItemUseCase)
{
  public async Task HandleAsync(string[] args)
  {
    if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
    {
      Console.WriteLine("Please provide a description for the work item.");

      return;
    }

    var description = args[0];

    var workItem = await addWorkItemUseCase.ExecuteAsync(description);

    Console.WriteLine($"Work item created with ID: {workItem.Id}");
  }
}