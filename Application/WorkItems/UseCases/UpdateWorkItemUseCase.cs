using Application.WorkItems.Exceptions;
using Domain.WorkItems.Repositories;

namespace Application.WorkItems.UseCases;

public class UpdateWorkItemUseCase(IWorkItemRepository workItemRepository)
{
  public async Task ExecuteAsync(int id, string description)
  {
    var workItem = await workItemRepository.GetByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    workItem.UpdateDescription(description);

    await workItemRepository.UpdateAsync(workItem);
  }
}
