using Domain.WorkItems.Entities;

namespace Application.WorkItems.UseCases.Dtos;

public record class ListWorkItemsQuery
{
  public WorkItemStatus? Status { get; init; }
}
