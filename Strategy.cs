// Define an interface for the strategy objects
public interface IStrategy
{
    void Execute();
}

// Define concrete implementations of the strategy interface
public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing strategy A");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing strategy B");
    }
}

// Define the context that will use the strategy objects
public class Context
{
    private IStrategy _strategy;

    // Constructor that takes a strategy object as a parameter
    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    // Method that uses the strategy object to execute a behavior
    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }

    // Method to set a new strategy object at runtime
    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
}

// Example usage of the strategy pattern
public static void Main(string[] args)
{
    // Create a context object with a ConcreteStrategyA object as the default strategy
    Context context = new Context(new ConcreteStrategyA());

    // Execute the default strategy
    context.ExecuteStrategy();

    // Set a new strategy (ConcreteStrategyB) at runtime
    context.SetStrategy(new ConcreteStrategyB());

    // Execute the new strategy
    context.ExecuteStrategy();
}
