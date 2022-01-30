namespace TaskSolvers.Solvers
{
    public interface ITaskSolver
    {
        bool CanSolveTask(int dayNumber);
        string SolvePartOne();
        string SolvePartTwo();
    }
}
