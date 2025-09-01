using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;

namespace Application.WorkItems.UseCases;

public class AddWorkItemUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<WorkItem> ExecuteAsync(string description)
  {
    var workItem = WorkItem.Create(description);

    return await workItemRepository.CreateAsync(workItem);
  }
}