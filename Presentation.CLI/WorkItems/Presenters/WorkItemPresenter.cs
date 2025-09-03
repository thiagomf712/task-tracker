namespace Presentation.CLI.WorkItems.Presenters;

using Domain.WorkItems.Entities;

public static class WorkItemPresenter
{
  public static void ToConsole(WorkItem workItem)
  {
    Console.WriteLine($"{workItem.Id} - {workItem.Description} ({workItem.Status})");
  }

  public static void ToConsole(IEnumerable<WorkItem> workItems)
  {
    Console.WriteLine(new string('-', 40));

    foreach (var workItem in workItems)
    {
      ToConsole(workItem);

      Console.WriteLine(new string('-', 40));
    }
  }
}