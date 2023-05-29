using Calculator.Domain.Models.Base;

namespace Calculator.Domain.Models.Aggregates
{
    public class FibonacciNumber : Entity
    {
        public int NumberId { get; set; }

        public long PreviousValue { get; set; }

        public long CurrentValue { get; set; }


        public void SetPreviousValue(long number)
        {
            PreviousValue = number;
        }

        public void SetCurrentValue(long number)
        {
            CurrentValue = number;
        }
    }
}