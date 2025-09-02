
namespace Domain.Shared.Exceptions.App;

public class InvalidStatusTransitionException : BusinessViolationException
{
  public InvalidStatusTransitionException()
  {
  }

  public InvalidStatusTransitionException(string message) : base(message)
  {
  }

  public InvalidStatusTransitionException(string message, Exception innerException) : base(message, innerException)
  {
  }
}
