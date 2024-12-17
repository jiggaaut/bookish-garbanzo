using MathApp.Core.Domain;
using MathApp.Core.Interfaces;

namespace MathApp.Core.Services;

public class QuadraticEquationSolver : IQuadraticEquationSolver
{
    public EquationSolution Solve(QuadraticEquation equation)
    {
        if (equation.A == 0) throw new ArgumentException("Coefficient A cannot be zero for a quadratic equation.");

        var discriminant = Math.Pow(equation.B, 2) - 4 * equation.A * equation.C;
        if (discriminant < 0) return new EquationSolution(null, null, false);

        var sqrtD = Math.Sqrt(discriminant);
        var root1 = (-equation.B + sqrtD) / (2 * equation.A);
        var root2 = (-equation.B - sqrtD) / (2 * equation.A);

        var solution = new EquationSolution(root1, root2, true);
        return solution;
    }
}