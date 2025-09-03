namespace Application.WorkItems.UseCases;

using Application.WorkItems.UseCases.Dtos;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;

public class ListWorkItemsUseCase(IWorkItemRepository workItemRepository)
{
  public async Task<IEnumerable<WorkItem>> ExecuteAsync(ListWorkItemsQuery query)
  {
    if (query.Status.HasValue)
    {
      return await workItemRepository.FindByStatusAsync(query.Status.Value);
    }

    return await workItemRepository.FindAllAsync();
  }
}