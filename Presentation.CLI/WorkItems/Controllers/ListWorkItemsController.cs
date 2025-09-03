namespace Presentation.CLI.WorkItems.Controllers;

using Application.WorkItems.UseCases;
using Domain.WorkItems.Entities;
using Presentation.CLI.WorkItems.Presenters;

public class ListWorkItemsController(ListWorkItemsUseCase listWorkItemsUseCase)
{
  public async Task HandleAsync(string[] args)
  {
    WorkItemStatus? statusFilter = null;

    var statusAllowed = new[] { "done", "todo", "in-progress" };

    if (args.Length > 0)
    {
      var statusArg = args[0].ToLowerInvariant();

      if (statusAllowed.Contains(statusArg))
      {
        statusFilter = statusArg switch
        {
          "done" => WorkItemStatus.Done,
          "todo" => WorkItemStatus.Todo,
          "in-progress" => WorkItemStatus.InProgress,
          _ => null,
        };
      }
      else
      {
        Console.WriteLine($"Invalid status filter. Allowed values are: {string.Join(", ", statusAllowed)}");
        return;
      }
    }

    var workItems = await listWorkItemsUseCase.ExecuteAsync(new() { Status = statusFilter });

    WorkItemPresenter.ToConsole(workItems);
  }
}