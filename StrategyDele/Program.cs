using System;

namespace StrategyDele
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new Context(() => Console.WriteLine("strategy work 1"));
      context.DoWork();
      context.Strategy = () => Console.WriteLine("strategy work 1");
      context.DoWork();

      Console.ReadKey();
    }
  }

  public class Context
  {
    public Context(Action strategy)
    {
      if (strategy == null) throw new ArgumentException(nameof(strategy));

      Strategy = strategy;
    }
    private Action _strategy;

    public Action Strategy
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
      Strategy();
    }
  }
}
