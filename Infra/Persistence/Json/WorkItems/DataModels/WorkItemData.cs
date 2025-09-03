namespace Infra.Persistence.Json.WorkItems.DataModels;

using Domain.WorkItems.Entities;

public record WorkItemData(
  int Id,
  string Description,
  WorkItemStatus Status,
  DateTime CreatedAt,
  DateTime UpdatedAt);