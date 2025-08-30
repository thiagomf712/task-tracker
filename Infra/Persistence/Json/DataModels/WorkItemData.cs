using Domain.Entities.WorkItem;

namespace Infra.Persistence.Json.DataModels;

public record WorkItemData(int Id, string Description, WorkItemStatus Status, DateTime CreatedAt, DateTime UpdatedAt);
