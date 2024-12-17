using MathApp.Core.Domain;

namespace MathApp.Core.Interfaces;

public interface ICoefficientReader
{
    IEnumerable<QuadraticEquation> GetEquations();
}