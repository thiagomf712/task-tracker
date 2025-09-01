using System.Text.Json.Serialization;
using Domain.WorkItems.Entities.Dtos;

namespace Domain.WorkItems.Entities;

public class WorkItem
{
  public int Id { get; }
  public string Description { get; private set; }
  public WorkItemStatus Status { get; private set; }
  public DateTime CreatedAt { get; }
  public DateTime UpdatedAt { get; private set; }

  [JsonIgnore]
  public bool IsNew => Id == default;

  public void UpdateDescription(string newDescription)
  {
    if (string.IsNullOrWhiteSpace(newDescription))
      throw new ArgumentException("Description should not be empty", nameof(newDescription));

    Description = newDescription.Trim();

    MarkAsUpdated();
  }

  public void MarkAsInProgress()
  {
    if (Status == WorkItemStatus.Done)
      throw new InvalidOperationException("Cannot mark a done task as in progress");

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
      throw new ArgumentException("Description should not be empty", nameof(description));

    var createdAt = DateTime.UtcNow;

    return new WorkItem(new()
    {
      Id = default,
      Description = description.Trim(),
      Status = WorkItemStatus.Todo,
      CreatedAt = createdAt,
      UpdatedAt = createdAt
    });
  }

  public static WorkItem Load(WorkItemsProps props)
  {
    return new WorkItem(props);
  }

  public WorkItem WithIdentity(int newId)
  {
    if (!IsNew)
      throw new InvalidOperationException("Cannot change the ID of an existing work item");

    return Load(new()
    {
      Id = newId,
      Description = Description,
      Status = Status,
      CreatedAt = CreatedAt,
      UpdatedAt = UpdatedAt
    });
  }
}

