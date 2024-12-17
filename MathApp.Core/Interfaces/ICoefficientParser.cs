using MathApp.Core.Domain;

namespace MathApp.Core.Interfaces;

public interface ICoefficientParser
{
    QuadraticEquation? ParseCoefficients(string? input);
}