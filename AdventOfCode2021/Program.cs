using TaskSolvers.Solvers;

Console.WriteLine("Advent of Code 2022 Solver");

//var dayOne = new DayOneSolver();
//var partOneSolution = dayOne.SolvePartOne();
//var partTwoSolution = dayOne.SolvePartTwo();

//Console.WriteLine($"Day one, part 1 solution: { partOneSolution }");
//Console.WriteLine($"Day one, part 2 solution: { partTwoSolution }");

var dayTwo = new DayTwoSolver();
var partOneSolution = dayTwo.SolvePartOne();
var partTwoSolution = dayTwo.SolvePartTwo();

Console.WriteLine($"Day two, part 1 solution: { partOneSolution }");
Console.WriteLine($"Day two, part 2 solution: { partTwoSolution }");

Console.ReadLine();