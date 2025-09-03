namespace Domain.Shared.Exceptions.Logic;

public class InvalidEntityStateException : LogicException
{
  public InvalidEntityStateException()
  {
  }

  public InvalidEntityStateException(string message)
    : base(message)
  {
  }

  public InvalidEntityStateException(string message, Exception innerException)
    : base(message, innerException)
  {
  }
}