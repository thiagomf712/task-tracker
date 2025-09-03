namespace Application.WorkItems.Exceptions;

using Application.Shared.Exceptions;

public class WorkItemNotFoundException : NotFoundException
{
  public WorkItemNotFoundException() { }

  public WorkItemNotFoundException(string message) : base(message) { }

  public WorkItemNotFoundException(string message, Exception innerException) : base(message, innerException)
  {
  }
}