using Calculator.Domain.Models.Aggregates;

namespace Fibonacci.Calculator.Domain.Models.Aggregates
{
    public interface IFibonacciService
    {
        Task CalculateNext(FibonacciNumber fibNumber);
    }
}
