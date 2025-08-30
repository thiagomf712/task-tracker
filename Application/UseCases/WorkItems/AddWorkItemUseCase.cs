using Domain.Entities.WorkItem;
using Domain.Repositories;

namespace Application.UseCases.WorkItems;

public class AddWorkItemUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<WorkItem> ExecuteAsync(string description)
  {
    var workItem = WorkItem.Create(description);

    return await workItemRepository.CreateAsync(workItem);
  }
}