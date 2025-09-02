using Application.Shared.Exceptions;

namespace Application.WorkItems.Exceptions;

public class WorkItemNotFoundException : NotFoundException
{
  public WorkItemNotFoundException() { }

  public WorkItemNotFoundException(string message) : base(message) { }

  public WorkItemNotFoundException(string message, Exception innerException) : base(message, innerException)
  {
  }
}
