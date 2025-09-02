namespace Domain.Shared.Exceptions.App;

public class InvalidInputException : AppException
{
  public InvalidInputException() { }

  public InvalidInputException(string message) : base(message) { }

  public InvalidInputException(string message, Exception innerException) : base(message, innerException)
  {
  }
}
