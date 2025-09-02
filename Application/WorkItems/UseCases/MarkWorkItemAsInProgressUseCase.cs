using Application.WorkItems.Exceptions;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;

namespace Application.WorkItems.UseCases;

public class MarkWorkItemAsInProgressUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<WorkItem> ExecuteAsync(int id)
  {
    var workItem = await workItemRepository.GetByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    if (workItem.Status == WorkItemStatus.InProgress)
      return workItem;

    workItem.MarkAsInProgress();

    await workItemRepository.UpdateAsync(workItem);

    return workItem;
  }
}