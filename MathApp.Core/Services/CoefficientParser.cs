using MathApp.Core.Domain;
using MathApp.Core.Interfaces;

namespace MathApp.Core.Services;

internal class CoefficientParser : ICoefficientParser
{
    public QuadraticEquation? ParseCoefficients(string? input)
    {
        if (string.IsNullOrEmpty(input)) return null;

        var arr = input.Split(' ');
        if (arr.Length != 3 ||
            !double.TryParse(arr[0], out var a) ||
            !double.TryParse(arr[1], out var b) ||
            !double.TryParse(arr[2], out var c)) return null;

        return new QuadraticEquation(a, b, c);
    }
}