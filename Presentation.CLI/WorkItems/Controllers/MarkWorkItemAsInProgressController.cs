namespace Presentation.CLI.WorkItems.Controllers;

using Application.WorkItems.UseCases;

public class MarkWorkItemAsInProgressController(MarkWorkItemAsInProgressUseCase markWorkItemAsInProgressUseCase)
{
  public async Task HandleAsync(string[] args)
  {
    if (args.Length < 1 || !int.TryParse(args[0], out var id))
    {
      Console.WriteLine("Please provide a valid ID for the work item.");

      return;
    }

    await markWorkItemAsInProgressUseCase.ExecuteAsync(id);

    Console.WriteLine($"Work item with ID: {id} marked as in progress.");
  }
}