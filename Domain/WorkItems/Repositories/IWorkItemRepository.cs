
using Domain.WorkItems.Entities;

namespace Domain.WorkItems.Repositories;

public interface IWorkItemRepository
{
  Task<WorkItem> CreateAsync(WorkItem workItem);
  Task<WorkItem?> GetByIdAsync(int id);
  Task UpdateAsync(WorkItem workItem);
}
