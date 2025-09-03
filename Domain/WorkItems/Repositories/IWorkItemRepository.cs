namespace Domain.WorkItems.Repositories;

using Domain.WorkItems.Entities;

public interface IWorkItemRepository
{
  Task<WorkItem?> FindByIdAsync(int id);
  Task<IEnumerable<WorkItem>> FindAllAsync();
  Task<IEnumerable<WorkItem>> FindByStatusAsync(WorkItemStatus status);
  Task<WorkItem> CreateAsync(WorkItem workItem);
  Task UpdateAsync(WorkItem workItem);
  Task DeleteAsync(WorkItem workItem);
}