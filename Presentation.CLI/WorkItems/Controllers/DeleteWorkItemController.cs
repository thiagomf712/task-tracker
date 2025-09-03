namespace Presentation.CLI.WorkItems.Controllers;

using Application.WorkItems.UseCases;

public class DeleteWorkItemController(DeleteWorkItemUseCase deleteWorkItemUseCase)
{
  public async Task HandleAsync(string[] args)
  {
    if (args.Length == 0 || !int.TryParse(args[0], out var id))
    {
      Console.WriteLine("Please provide a valid work item ID.");

      return;
    }

    await deleteWorkItemUseCase.ExecuteAsync(id);
  }
}