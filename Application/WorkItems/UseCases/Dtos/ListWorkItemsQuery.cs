namespace Application.WorkItems.UseCases.Dtos;

using Domain.WorkItems.Entities;

public record class ListWorkItemsQuery
{
  public WorkItemStatus? Status { get; init; }
}