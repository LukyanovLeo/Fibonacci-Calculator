using Calculator.Domain.Models.Aggregates;
using Fibonacci.Calculator.Domain.Models.Aggregates;

namespace Fibonacci.Calculator.Infrastructure.Services
{
    public class FibonacciService : IFibonacciService
    {
        public async Task CalculateNext(FibonacciNumber fibNumber)
        {
            var buffer = fibNumber.CurrentValue + fibNumber.PreviousValue;
            fibNumber.SetPreviousValue(fibNumber.CurrentValue);
            fibNumber.SetCurrentValue(buffer);
        }
    }
}
