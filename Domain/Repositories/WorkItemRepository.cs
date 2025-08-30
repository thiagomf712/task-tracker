using Domain.Entities.WorkItem;

namespace Domain.Repositories;

public interface IWorkItemRepository
{
  Task<WorkItem> CreateAsync(WorkItem workItem);
}
