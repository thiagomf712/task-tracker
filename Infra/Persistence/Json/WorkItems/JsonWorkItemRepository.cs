using System.Text.Json;
using Domain.WorkItems.Entities;
using Domain.WorkItems.Repositories;
using Infra.Persistence.Json.WorkItems.DataModels;
using Infra.Persistence.Json.WorkItems.Mappers;

namespace Infra.Persistence.Json.WorkItems;

public class JsonWorkItemRepository : IWorkItemRepository
{
  private readonly JsonSerializerOptions _jsonOptions = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
  };

  private readonly List<WorkItem> _workItems;
  private readonly string _filePath;

  public JsonWorkItemRepository(string filePath)
  {
    _filePath = filePath;
    _workItems = LoadWorkItemsFromJson();
  }

  private List<WorkItem> LoadWorkItemsFromJson()
  {
    if (!File.Exists(_filePath))
      return [];

    var json = File.ReadAllText(_filePath);

    var itemsAsData = JsonSerializer.Deserialize<List<WorkItemData>>(json, _jsonOptions);

    return WorkItemMapper.ToDomain(itemsAsData ?? []);
  }

  private int GetNextId()
  {
    return _workItems.Count != 0 ? _workItems.Max(wi => wi.Id) + 1 : 1;
  }

  public async Task SaveWorkItemsToJsonAsync()
  {
    var json = JsonSerializer.Serialize(_workItems, _jsonOptions);

    await File.WriteAllTextAsync(_filePath, json);
  }

  public Task<WorkItem> CreateAsync(WorkItem workItem)
  {
    var newId = GetNextId();

    WorkItem persistentWorkItem = workItem.WithIdentity(newId);

    _workItems.Add(persistentWorkItem);

    return Task.FromResult(persistentWorkItem);
  }

  public Task<WorkItem?> GetByIdAsync(int id)
  {
    var workItem = _workItems.FirstOrDefault(wi => wi.Id == id);

    return Task.FromResult(workItem);
  }

  public Task UpdateAsync(WorkItem workItem)
  {
    var index = _workItems.FindIndex(wi => wi.Id == workItem.Id);

    if (index != -1)
    {
      _workItems[index] = workItem;
    }

    return Task.CompletedTask;
  }

  public Task DeleteAsync(WorkItem workItem)
  {
    var index = _workItems.FindIndex(wi => wi.Id == workItem.Id);

    if (index != -1)
    {
      _workItems.RemoveAt(index);
    }

    return Task.CompletedTask;
  }
}
