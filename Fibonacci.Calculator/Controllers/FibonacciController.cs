using Calculator.Domain.Models.Aggregates;
using EasyNetQ;
using Fibonacci.Calculator;
using Fibonacci.Calculator.Domain.Models.Aggregates;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Calculator.Controllers
{
    [Route("api/fibonacci")]
    public class FibonacciController : Controller
    {
        private readonly IBus _bus;
        private readonly IFibonacciService _fibonacciService;


        public FibonacciController(IBus bus, IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
            _bus = bus;

            var queue = _bus.Advanced.QueueDeclare(Config.FIBONACCI_QUEUE);
            var exchange = _bus.Advanced.ExchangeDeclare(Config.FIBONACCI_EXCHANGE, ExchangeType.Topic);
            _bus.Advanced.Bind(exchange, queue, Config.FIBONACCI_QUEUE_WILDCARD);
        }


        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> Calculate([FromBody] FibonacciNumber message)
        {
            await _fibonacciService.CalculateNext(message);
            await _bus.SendReceive.SendAsync(Config.FIBONACCI_QUEUE, message);

            return Ok();
        }
    }
}
