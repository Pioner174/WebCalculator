using WebCalculator.Services.Abstraction;

namespace WebCalculator.Services
{
    public class Addition : IOperation
    {
        public int Priority => 1;
        public decimal Execute(decimal left, decimal right)
        {
            return left + right;
        }
    }

    public class Subtraction : IOperation
    {
        public int Priority => 1;
        public decimal Execute(decimal left, decimal right)
        {
            return left - right;
        }
    }

    public class Multiplication : IOperation
    {
        public int Priority => 1;
        public decimal Execute(decimal left, decimal right)
        {
            return left * right;
        }
    }

    public class Division : IOperation
    {
        public int Priority => 1;
        public decimal Execute(decimal left, decimal right)
        {
            if (right == 0)
                throw new DivideByZeroException("Ошибка деления на 0");

            return left / right;
        }
    }
}
