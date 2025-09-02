namespace Domain.Shared.Exceptions.App;

public class BusinessViolationException : AppException
{
  public BusinessViolationException() { }

  public BusinessViolationException(string message) : base(message) { }

  public BusinessViolationException(string message, Exception innerException) : base(message, innerException)
  {
  }
}
