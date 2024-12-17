using MathApp.Core.Domain;

namespace MathApp.Core.Interfaces;

public interface IQuadraticEquationSolver
{
    EquationSolution Solve(QuadraticEquation equation);
}