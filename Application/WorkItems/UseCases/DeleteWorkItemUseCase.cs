using Application.WorkItems.Exceptions;
using Domain.WorkItems.Repositories;

namespace Application.WorkItems.UseCases;

public class DeleteWorkItemUseCase(IWorkItemRepository workItemRepository)
{
  public async Task ExecuteAsync(int id)
  {
    var workItem = await workItemRepository.GetByIdAsync(id)
      ?? throw new WorkItemNotFoundException($"Work item with ID {id} not found.");

    await workItemRepository.DeleteAsync(workItem);
  }
}
