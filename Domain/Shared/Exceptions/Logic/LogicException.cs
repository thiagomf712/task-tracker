namespace Domain.Shared.Exceptions.Logic;

public abstract class LogicException : Exception
{
  protected LogicException() { }

  protected LogicException(string message) : base(message) { }

  protected LogicException(string message, Exception innerException) : base(message, innerException)
  {
  }
}
