using WebCalculator;
using WebCalculator.Services;
using WebCalculator.Services.Abstraction;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        private ICalculator _calculator; //ссылка на сервис калькулятора

        [SetUp]
        public void Setup()
        {
            _calculator = new CalculatorRPN(); 
        }

        [Test]
        public void Test_Addition()
        {
            string expression = "2+3";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Test_Subtraction()
        {
            string expression = "5-2";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Test_Multiplication()
        {
            string expression = "4*3";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Test_Division()
        {
            string expression = "8/2";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Test_Parentheses()
        {
            string expression = "(2+3)*2";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Test_Parentheses2()
        {
            string expression = "(2.05+0.05)*2/0.2";
            var result = _calculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void Test_InvalidExpression()
        {
            string expression = "2++3"; // Некорректное выражение

            Assert.Throws<InvalidOperationException>(() =>
            {
                _calculator.Calculate(expression);
            });
        }
    }
}
