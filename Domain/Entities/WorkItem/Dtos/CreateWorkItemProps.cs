namespace Domain.Entities.WorkItem.Dtos;

public record CreateWorkItemProps
{
  public required string Description { get; init; }
}

