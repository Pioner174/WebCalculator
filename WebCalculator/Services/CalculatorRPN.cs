using WebCalculator.Services.Abstraction;

namespace WebCalculator.Services
{
    public class CalculatorRPN : ICalculator
    {
        //Словарь операций
        private readonly Dictionary<string, IOperation> _operations;

        public CalculatorRPN()
        {
            _operations = new Dictionary<string, IOperation>
            {
                { "+", new Addition() },
                { "-", new Subtraction() },
                { "*", new Multiplication() },
                { "/", new Division() }
            };
        }

        public double Calculate(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
