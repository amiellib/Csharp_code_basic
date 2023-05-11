using System;

interface IMyDependency
{
    void DoSomething();
}

class MyDependency : IMyDependency
{
    public void DoSomething()
    {
        Console.WriteLine("MyDependency: Doing something...");
    }
}

class MyClass
{
    private readonly IMyDependency _dependency;

    public MyClass(IMyDependency dependency)
    {
        _dependency = dependency;
    }

    public void DoSomething()
    {
        Console.WriteLine("MyClass: Doing something...");
        _dependency.DoSomething();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMyDependency dependency = new MyDependency();
        MyClass myClass = new MyClass(dependency);

        myClass.DoSomething();
    }
}
