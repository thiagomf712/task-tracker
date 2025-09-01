using Domain.WorkItems.Entities;

namespace Infra.Persistence.Json.WorkItems.DataModels;

public record WorkItemData(int Id, string Description, WorkItemStatus Status, DateTime CreatedAt, DateTime UpdatedAt);
