namespace Domain.Shared.Exceptions.App;

public abstract class AppException : Exception
{
  protected AppException() { }

  protected AppException(string message) : base(message) { }

  protected AppException(string message, Exception innerException) : base(message, innerException) { }
}