namespace Application.Shared.Exceptions;

using Domain.Shared.Exceptions.App;

public abstract class NotFoundException : AppException
{
  protected NotFoundException()
  {
  }

  protected NotFoundException(string message) : base(message)
  {
  }

  protected NotFoundException(string message, Exception innerException)
    : base(message, innerException)
  {
  }
}