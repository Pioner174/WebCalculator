namespace WebCalculator.Services.Abstraction
{
    public interface IOperation
    {
        int Priority { get; }
        decimal Execute(decimal left, decimal right);
    }
}
