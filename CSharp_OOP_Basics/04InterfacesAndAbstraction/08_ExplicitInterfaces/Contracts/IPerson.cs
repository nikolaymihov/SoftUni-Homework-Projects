namespace ExplicitInterfaces
{ 
    public interface IPerson : INameable
    {
        int Age { get; }
        string GetName();
    }
}
