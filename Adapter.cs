// The Target defines the domain-specific interface used by the client code.
public interface ITarget
{
    string GetRequest();
}

// The Adaptee contains some useful behavior, but its interface is incompatible with the existing client code.
public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}

// The Adapter makes the Adaptee's interface compatible with the Target's interface.
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        this._adaptee = adaptee;
    }

    public string GetRequest()
    {
        return "This is the new request: " + this._adaptee.GetSpecificRequest();
    }
}

// The client code supports all classes that follow the ITarget interface.
public class Client
{
    public void Request(ITarget target)
    {
        Console.WriteLine(target.GetRequest());
    }
}

// Client code usage
static void Main(string[] args)
{
    Adaptee adaptee = new Adaptee();
    ITarget target = new Adapter(adaptee);
    Client client = new Client();
    client.Request(target);
}
