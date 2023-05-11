using System;
using System.Collections.Generic;

interface IObserver
{
    void Update(ISubject subject);
}

interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private int state;

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached an observer.");
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer.");
    }

    public void Notify()
    {
        Console.WriteLine("Subject: Notifying observers...");
        foreach (IObserver observer in observers)
        {
            observer.Update(this);
        }
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("\nSubject: I'm doing something important.");
        state = new Random().Next(0, 10);

        Console.WriteLine($"Subject: My state has just changed to: {state}");
        Notify();
    }

    public int GetState()
    {
        return state;
    }
}

class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as ConcreteSubject).GetState() < 3)
        {
            Console.WriteLine("ConcreteObserverA: Reacted to the event.");
        }
    }
}

class ConcreteObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as ConcreteSubject).GetState() == 0 || (subject as ConcreteSubject).GetState() >= 5)
        {
            Console.WriteLine("ConcreteObserverB: Reacted to the event.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();

        ConcreteObserverA observerA = new ConcreteObserverA();
        subject.Attach(observerA);

        ConcreteObserverB observerB = new ConcreteObserverB();
        subject.Attach(observerB);

        subject.SomeBusinessLogic();
        subject.SomeBusinessLogic();

        subject.Detach(observerB);

        subject.SomeBusinessLogic();
    }
}
