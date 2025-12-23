namespace Domain.Homes.Exceptions;

public class HomeNameIsNotUniqueException : DomainException
{
    public HomeNameIsNotUniqueException(string homeName)
        : base($"The home name '{homeName}' is already in use.")
    {

    }
}
