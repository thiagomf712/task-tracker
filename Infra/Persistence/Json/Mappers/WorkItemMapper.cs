using Domain.Entities.WorkItem;
using Infra.Persistence.Json.DataModels;

namespace Infra.Persistence.Json.Mappers;

public static class WorkItemMapper
{
  public static WorkItem ToDomain(WorkItemData data)
  {
    return WorkItem.Load(new()
    {
      Id = data.Id,
      Description = data.Description,
      Status = data.Status,
      CreatedAt = data.CreatedAt,
      UpdatedAt = data.UpdatedAt
    });
  }

  public static List<WorkItem> ToDomain(List<WorkItemData> dataList)
  {
    return [.. dataList.Select(ToDomain)];
  }
}