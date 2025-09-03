namespace Presentation.CLI.WorkItems.Controllers;

using Application.WorkItems.UseCases;

public class UpdateWorkItemController(UpdateWorkItemUseCase updateWorkItemUseCase)
{
  public async Task HandleAsync(string[] args)
  {
    if (args.Length < 2 || !int.TryParse(args[0], out var id) || string.IsNullOrWhiteSpace(args[1]))
    {
      Console.WriteLine("Please provide a valid ID and a new description for the work item.");

      return;
    }

    var description = args[1];

    await updateWorkItemUseCase.ExecuteAsync(id, description);

    Console.WriteLine($"Work item with ID: {id} updated successfully.");
  }
}