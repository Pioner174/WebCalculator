using System.Text.RegularExpressions;
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
            //1. Разделение строки на символы знаков и числа
            var symbols = GetSymbols(expression);
            //2. Преобразование в RPN
            //3. Вычисление значения
            throw new NotImplementedException();
        }

        private List<string> GetSymbols(string input)
        {
            var regex = new Regex("^(((\\d*\\.?\\d*)|\\w)([+-/*]))*((\\d*\\.?\\d*)|\\w)$");
            var matches = regex.Matches(input);

            var result = new List<string>();
            foreach (string value in matches)
            {
                result.Add(value);
            }

            return result;
        }
    }
}
