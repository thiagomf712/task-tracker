namespace Infra.Persistence.Json.WorkItems;

using System.Text.Json;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;
using Infra.Persistence.Json.WorkItems.DataModels;
using Infra.Persistence.Json.WorkItems.Mappers;

public class JsonWorkItemRepository : IWorkItemRepository
{
  private readonly JsonSerializerOptions jsonOptions = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
  };

  private readonly List<WorkItem> workItems;
  private readonly string filePath;

  public JsonWorkItemRepository(string filePath)
  {
    this.filePath = filePath;
    workItems = LoadWorkItemsFromJson();
  }

  public async Task SaveWorkItemsToJsonAsync()
  {
    var json = JsonSerializer.Serialize(workItems, jsonOptions);

    await File.WriteAllTextAsync(filePath, json);
  }

  public async Task<IEnumerable<WorkItem>> FindAllAsync()
  {
    return await Task.FromResult(workItems);
  }

  public async Task<IEnumerable<WorkItem>> FindByStatusAsync(WorkItemStatus status)
  {
    var filteredItems = workItems.Where(wi => wi.Status == status);

    return await Task.FromResult(filteredItems);
  }

  public Task<WorkItem?> FindByIdAsync(int id)
  {
    var workItem = workItems.FirstOrDefault(wi => wi.Id == id);

    return Task.FromResult(workItem);
  }

  public Task<WorkItem> CreateAsync(WorkItem workItem)
  {
    var newId = GetNextId();

    WorkItem persistentWorkItem = workItem.WithIdentity(newId);

    workItems.Add(persistentWorkItem);

    return Task.FromResult(persistentWorkItem);
  }

  public Task UpdateAsync(WorkItem workItem)
  {
    var index = workItems.FindIndex(wi => wi.Id == workItem.Id);

    if (index != -1)
    {
      workItems[index] = workItem;
    }

    return Task.CompletedTask;
  }

  public Task DeleteAsync(WorkItem workItem)
  {
    var index = workItems.FindIndex(wi => wi.Id == workItem.Id);

    if (index != -1)
    {
      workItems.RemoveAt(index);
    }

    return Task.CompletedTask;
  }

  private List<WorkItem> LoadWorkItemsFromJson()
  {
    if (!File.Exists(filePath))
    {
      return [];
    }

    var json = File.ReadAllText(filePath);

    var itemsAsData = JsonSerializer.Deserialize<List<WorkItemData>>(json, jsonOptions);

    return WorkItemMapper.ToDomain(itemsAsData ?? []);
  }

  private int GetNextId()
  {
    return workItems.Count != 0 ? workItems.Max(wi => wi.Id) + 1 : 1;
  }
}