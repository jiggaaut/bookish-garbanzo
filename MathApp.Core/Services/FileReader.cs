using MathApp.Core.Domain;
using MathApp.Core.Interfaces;

namespace MathApp.Core.Services;

internal class FileReader : ICoefficientReader
{
    private readonly ICoefficientParser _parser;
    private readonly string _filePath;

    public FileReader(ICoefficientParser parser, string filePath)
    {
        _parser = parser;
        _filePath = filePath;
    }

    public IEnumerable<QuadraticEquation> GetEquations()
    {
        var equations = new List<QuadraticEquation>();
        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var coefficients = _parser.ParseCoefficients(line);
            if (coefficients != null)
            {
                equations.Add(coefficients);
            }
        }
        return equations;
    }
}