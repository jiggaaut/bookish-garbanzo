using MathApp.Core.Interfaces;
using MathApp.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MathApp.Core;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection container, IConfigurationRoot configurationRoot)
    {
        var mode = configurationRoot["mode"];
        switch (mode)
        {
            case "file":
            {
                var filePath = configurationRoot["filePath"];
                if (filePath == null) throw new ArgumentException($"Set {nameof(filePath)} for program");

                container.AddScoped<ICoefficientReader, FileReader>(e => new FileReader(e.GetRequiredService<ICoefficientParser>(), filePath));
                break;
            }
            case "console":
            {
                container.AddScoped<ICoefficientReader, ConsoleReader>();
                break;
            }
            default:
            {
                throw new ArgumentException($"Set {nameof(mode)} for program");
            }
        }

        container.AddScoped<ICoefficientParser, CoefficientParser>();
        container.AddScoped<IQuadraticEquationSolver, QuadraticEquationSolver>();
    }
}