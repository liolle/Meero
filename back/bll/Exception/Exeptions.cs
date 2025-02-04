namespace meero.bll;

public abstract class ApiException : Exception
{
    public ApiException(string message) : base(message)
    {
    }
}

public sealed class DuplicateEmailException : ApiException
{
    public DuplicateEmailException() : base("Email already exist")
    {
    }
}

public sealed class DuplicatePowerException : ApiException
{
    public DuplicatePowerException() : base("Power already exist")
    {
    }
}

public sealed class InvalidCredentialException : ApiException
{
    public InvalidCredentialException() : base("Invalid credential")
    {
    }
}

public sealed class UserNotFountException : ApiException
{
    public UserNotFountException() : base("User does not exist")
    {
    }
}

public sealed class DatabaseException : ApiException
{
    public DatabaseException() : base("Database Exception")
    {
    }
}


public sealed class InvalidTokenException : ApiException
{
    public InvalidTokenException() : base("Invalid token.")
    {
    }
}

public sealed class TokenException : ApiException
{
    public TokenException() : base("Could not generate token.")
    {
    }
}