using MathApp.Core.Domain;
using MathApp.Core.Interfaces;

namespace MathApp.Core.Services;

internal class ConsoleReader : ICoefficientReader
{
    private readonly ICoefficientParser _parser;

    public ConsoleReader(ICoefficientParser parser)
    {
        _parser = parser;
    }

    public IEnumerable<QuadraticEquation> GetEquations()
    {
        var equations = new List<QuadraticEquation>();
        Console.WriteLine("Enter coefficients (A B C), one equation per line, empty line to finish:");
        string? input;
        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            var coefficients = _parser.ParseCoefficients(input);
            if (coefficients != null)
            {
                equations.Add(coefficients);
            }
        }

        return equations;
    }
}