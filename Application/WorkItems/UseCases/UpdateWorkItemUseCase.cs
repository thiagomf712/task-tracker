namespace Application.WorkItems.UseCases;

using Application.WorkItems.Exceptions;
using Domain.WorkItems.Repositories;

public class UpdateWorkItemUseCase(IWorkItemRepository workItemRepository)
{
  public async Task ExecuteAsync(int id, string description)
  {
    var workItem = await workItemRepository.FindByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    workItem.UpdateDescription(description);

    await workItemRepository.UpdateAsync(workItem);
  }
}