using System;

namespace StrategyPoly
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new Context(new ConcreteStrategy1());
      context.DoWork();
      context.Strategy = new ConcreteStrategy2();
      context.DoWork();

      Console.ReadKey();
    }
  }

  public class Context
  {
    public Context(IStrategy strategy)
    {
      if (strategy == null) throw new ArgumentException(nameof(strategy));

      Strategy = strategy;
    }
    private IStrategy _strategy;

    public IStrategy Strategy
    {
      get { return _strategy; }
      set
      {
        if (value == null) throw new ArgumentException(nameof(value));
        _strategy = value;
      }
    }
    public void DoWork()
    {
      Strategy.DoWork();
    }
  }

  public interface IStrategy
  {
    void DoWork();
  }

  public class ConcreteStrategy1 : IStrategy
  {
    public void DoWork()
    {
      Console.WriteLine("strategy work 1");
    }
  }

  public class ConcreteStrategy2 : IStrategy
  {
    public void DoWork()
    {
      Console.WriteLine("strategy work 2");
    }
  }
}
