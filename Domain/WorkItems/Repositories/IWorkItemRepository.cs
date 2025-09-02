
using Domain.WorkItems.Entities;

namespace Domain.WorkItems.Repositories;

public interface IWorkItemRepository
{
  Task<WorkItem?> FindByIdAsync(int id);
  Task<IEnumerable<WorkItem>> FindAllAsync();
  Task<IEnumerable<WorkItem>> FindByStatusAsync(WorkItemStatus status);
  Task<WorkItem> CreateAsync(WorkItem workItem);
  Task UpdateAsync(WorkItem workItem);
  Task DeleteAsync(WorkItem workItem);
}
