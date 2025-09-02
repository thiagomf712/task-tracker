using Application.WorkItems.Exceptions;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;

namespace Application.WorkItems.UseCases;

public class MarkWorkItemAsDoneUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<WorkItem> ExecuteAsync(int id)
  {
    var workItem = await workItemRepository.FindByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    if (workItem.Status == WorkItemStatus.Done)
      return workItem;

    workItem.MarkAsDone();

    await workItemRepository.UpdateAsync(workItem);

    return workItem;
  }
}