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

        private List<string> ConvertToRPN(List<string> symbols)
        {
            var result = new List<string>();
            var operators = new Stack<string>();

            foreach (string value in symbols)
            {
                if(double.TryParse(value, out _))
                {
                    result.Add(value);
                }
                else if (value == "(") //Открывающая скобка
                {
                    operators.Push(value);
                }
                else if (value == ")") //Закрывающая скобка
                {
                    if (operators.Count > 0)
                    {
                        while (operators.Peek() != "(")
                        {
                            result.Add(operators.Pop());
                        }
                    }

                }
                else if (_operations.ContainsKey(value))// Обработка знака
                {
                    if (operators.Count > 0)
                    {
                        while (_operations.ContainsKey(operators.Peek()))//Поработать над очередностью
                        {
                            result.Add(operators.Pop());
                        }
                    }
                    else
                    {
                        operators.Push(value);
                    }

                    
                }


            }

            while (operators.Count > 0)
            {
                result.Add(operators.Pop());
            }

            return result;

        }
    }
}
