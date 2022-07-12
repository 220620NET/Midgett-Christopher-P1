
namespace CustomExceptions;

public class ResourceNotFoundExceptions : System.Exception
{
    public ResourceNotFoundExceptions() { }
    public ResourceNotFoundExceptions(string message) : base(message) { }
    public ResourceNotFoundExceptions(string message, System.Exception inner) : base(message, inner) { }
    protected ResourceNotFoundExceptions(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class UsernameNotAvailableException : System.Exception
{
    public UsernameNotAvailableException() { }
    public UsernameNotAvailableException(string message) : base(message) { }
    public UsernameNotAvailableException(string message, System.Exception inner) : base(message, inner) { }
    protected UsernameNotAvailableException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class InvalidCredentialsException : System.Exception
{
    public InvalidCredentialsException() { }
    public InvalidCredentialsException(string message) : base(message) { }
    public InvalidCredentialsException(string message, System.Exception inner) : base(message, inner) { }
    protected InvalidCredentialsException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}