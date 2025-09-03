namespace Application.WorkItems.UseCases;

using Application.WorkItems.Exceptions;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;

public class MarkWorkItemAsInProgressUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<WorkItem> ExecuteAsync(int id)
  {
    var workItem = await workItemRepository.FindByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    if (workItem.Status == WorkItemStatus.InProgress)
    {
      return workItem;
    }

    workItem.MarkAsInProgress();

    await workItemRepository.UpdateAsync(workItem);

    return workItem;
  }
}