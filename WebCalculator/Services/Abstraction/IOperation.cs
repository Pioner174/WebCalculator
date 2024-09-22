namespace WebCalculator.Services.Abstraction
{
    public interface IOperation
    {
        int Priority { get; }
        double Execute(double left, double right);
    }
}
