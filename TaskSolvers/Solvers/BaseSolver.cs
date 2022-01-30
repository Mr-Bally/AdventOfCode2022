using System.Text.RegularExpressions;
using TaskSolvers.Common;

namespace TaskSolvers.Solvers
{
    public abstract class BaseSolver : ITaskSolver
    {
        public abstract int DayNumber { get; }

        public bool CanSolveTask(int daynumber) => daynumber == DayNumber;

        public abstract string SolvePartOne();

        public abstract string SolvePartTwo();

        internal List<int> GetInputAsListOfInts(string filePath)
        {
            var fileReader = new FileReader();
            return fileReader.ReadFileToListOfInts(filePath);
        }

        internal List<string> GetInputAsListOfStrings(string filePath)
        {
            var fileReader = new FileReader();
            return fileReader.ReadFileToListOfString(filePath);
        }

        internal int GetIntFromString(string line) => int.Parse(Regex.Match(line, @"\d+").Value);
    }
}
