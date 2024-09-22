using System.Globalization;
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
            var rpnString = ConvertToRPN(symbols);

            //3. Вычисление значения
            var result = CalculationRPN(rpnString);
            
            return result;
        }

        private List<string> GetSymbols(string input)
        {
            var regex = new Regex(@"\d+(\.\d+)?|[\+\-\*/\(\)]");
            var matches = regex.Matches(input);

            var result = new List<string>();
            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }

            return result;
        }

        private List<string> ConvertToRPN(List<string> symbols)
        {
            var result = new List<string>();
            var operators = new Stack<string>();

            foreach (string value in symbols)
            {
                if(double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    result.Add(value);
                }
                else if (value == "(") //Открывающая скобка
                {
                    operators.Push(value);
                }
                else if (value == ")") //Закрывающая скобка
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        result.Add(operators.Pop());
                    }

                    operators.Pop();
                }
                else if (_operations.ContainsKey(value))// Обработка знака
                {
                    
                    while (operators.Count > 0 && _operations.ContainsKey(operators.Peek()) &&
                        (_operations[operators.Peek()].Priority > _operations[value].Priority))//Реализация с приоритетом
                    {     
                        result.Add(operators.Pop());
                    }
                    
                    operators.Push(value);
                      
                }
            }

            while (operators.Count > 0)
            {
                result.Add(operators.Pop());
            }

            return result;

        }

        private double CalculationRPN(List<string> tokens)
        {
            var stack = new Stack<double>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                {
                    stack.Push(number);
                }
                else if (_operations.ContainsKey(token))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    var result = _operations[token].Execute(left, right);
                    stack.Push(result);
                }
            }

            return stack.Pop();
        }
    }
}
