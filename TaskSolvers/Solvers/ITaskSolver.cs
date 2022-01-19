namespace TaskSolvers.Solvers
{
    internal interface ITaskSolver
    {
        bool CanSolveTask(int dayNumber);
        string SolvePartOne();
        string SolvePartTwo();
    }
}
