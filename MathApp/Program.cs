using MathApp.Core;
using MathApp.Core.Domain;
using MathApp.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var container = new ServiceCollection();
var configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

container.AddServices(configurationRoot);
container.AddSingleton<IConfiguration>(configurationRoot);
container.AddSingleton(configurationRoot);

var serviceProvider = container.BuildServiceProvider();

Console.WriteLine("Hello and Welcome!");

using var scope = serviceProvider.CreateScope();
var reader = scope.ServiceProvider.GetRequiredService<ICoefficientReader>();
var solver = scope.ServiceProvider.GetRequiredService<IQuadraticEquationSolver>();

var equations = reader.GetEquations();
foreach (var equation in equations)
{
    var solution = solver.Solve(equation);
    WriteResult(equation, solution);
}

return 1;

void WriteResult(QuadraticEquation equation, EquationSolution solution)
{
    Console.WriteLine($"Equation: {equation.A}x^2 + {equation.B}x + {equation.C} = 0");

    if (!solution.HasRealSolutions)
    {
        Console.WriteLine("No real solutions");
    }
    else
    {
        Console.WriteLine($"Solutions: x1 = {solution.Root1}, x2 = {solution.Root2}");
    }
}
