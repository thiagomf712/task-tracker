namespace Domain.WorkItems.Entities;

using System.Text.Json.Serialization;
using Domain.Shared.Exceptions.App;
using Domain.Shared.Exceptions.Logic;
using Domain.WorkItems.Entities.Dtos;

public class WorkItem
{
  public int Id { get; }
  public string Description { get; private set; }
  public WorkItemStatus Status { get; private set; }
  public DateTime CreatedAt { get; }
  public DateTime UpdatedAt { get; private set; }

  [JsonIgnore]
  public bool IsNew => Id == default;

  private WorkItem(WorkItemsProps props)
  {
    Id = props.Id;
    Description = props.Description;
    Status = props.Status;
    CreatedAt = props.CreatedAt;
    UpdatedAt = props.UpdatedAt;
  }

  public static WorkItem Create(string description)
  {
    if (string.IsNullOrWhiteSpace(description))
    {
      throw new InvalidInputException("Description should not be empty");
    }

    var createdAt = DateTime.UtcNow;

    return new WorkItem(new()
    {
      Id = default,
      Description = description.Trim(),
      Status = WorkItemStatus.Todo,
      CreatedAt = createdAt,
      UpdatedAt = createdAt,
    });
  }

  public static WorkItem Load(WorkItemsProps props)
  {
    return new WorkItem(props);
  }

  public WorkItem WithIdentity(int newId)
  {
    if (!IsNew)
    {
      throw new InvalidEntityStateException("Cannot change the ID of an existing work item");
    }

    return Load(new()
    {
      Id = newId,
      Description = Description,
      Status = Status,
      CreatedAt = CreatedAt,
      UpdatedAt = UpdatedAt,
    });
  }

  public void UpdateDescription(string newDescription)
  {
    if (string.IsNullOrWhiteSpace(newDescription))
    {
      throw new InvalidInputException("Description should not be empty");
    }

    Description = newDescription.Trim();

    MarkAsUpdated();
  }

  public void MarkAsInProgress()
  {
    if (Status == WorkItemStatus.Done)
    {
      throw new InvalidStatusTransitionException("Cannot mark a done task as in progress");
    }

    Status = WorkItemStatus.InProgress;

    MarkAsUpdated();
  }

  public void MarkAsDone()
  {
    Status = WorkItemStatus.Done;
    MarkAsUpdated();
  }

  private void MarkAsUpdated()
  {
    UpdatedAt = DateTime.UtcNow;
  }
}