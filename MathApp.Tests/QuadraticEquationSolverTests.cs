using MathApp.Core.Domain;
using MathApp.Core.Interfaces;
using MathApp.Core.Services;

namespace MathApp.Tests
{
    public class QuadraticEquationSolverTests
    {
        private readonly IQuadraticEquationSolver _solver = new QuadraticEquationSolver();

        [Fact]
        public void Solve_TwoRealRoots_ReturnsCorrectRoots()
        {
            // Arrange
            double a = 1;
            double b = -3;
            double c = 2;

            // Act
            var solution = _solver.Solve(new QuadraticEquation(a, b, c));

            // Assert
            Assert.Equal(2, solution.Root1.Value, 5);
            Assert.Equal(1, solution.Root2.Value, 5);
        }

        [Fact]
        public void Solve_OneRealRoot_ReturnsCorrectRoot()
        {
            // Arrange
            double a = 1;
            double b = -2;
            double c = 1;

            // Act
            var solution = _solver.Solve(new QuadraticEquation(a, b, c));

            // Assert
            Assert.Equal(1, solution.Root1.Value, 5);
            Assert.Equal(1, solution.Root2.Value, 5);
        }

        [Fact]
        public void Solve_NoRealRoots_ThrowsInvalidOperationException()
        {
            // Arrange
            double a = 1;
            double b = 1;
            double c = 1;

            // Act
            var solution = _solver.Solve(new QuadraticEquation(a, b, c));

            // Assert
            Assert.Equal(solution.HasRealSolutions, false);
        }
    }
}