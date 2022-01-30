using Microsoft.Extensions.DependencyInjection;
using TaskSolvers.Solvers;

Console.WriteLine("Advent of Code 2022 Solver");

var serviceProvider = RegisterServices();

Console.WriteLine("Please enter the day number you wish to solve");
var consoleLine = Console.ReadLine();
int dayNumber;


if (!int.TryParse(consoleLine, out dayNumber))
{
    Console.WriteLine("Invalid number entered. Exiting");
    Console.ReadLine();
    return;
}

var taskSolver = serviceProvider.GetServices<ITaskSolver>()
    .FirstOrDefault(x => x.CanSolveTask(dayNumber));

if (taskSolver is null)
{
    Console.WriteLine($"No task solver for day number {dayNumber}. Exiting");
    Console.ReadLine();
    return;
}

var partOneSolution = taskSolver.SolvePartOne();
var partTwoSolution = taskSolver.SolvePartTwo();

Console.WriteLine($"Day {dayNumber}, part 1 solution: { partOneSolution }");
Console.WriteLine($"Day {dayNumber}, part 2 solution: { partTwoSolution }");
Console.ReadLine();

static ServiceProvider RegisterServices()
{

    return new ServiceCollection()
        .AddScoped<ITaskSolver, DayOneSolver>()
        .AddScoped<ITaskSolver, DayTwoSolver>()
        .BuildServiceProvider();
}