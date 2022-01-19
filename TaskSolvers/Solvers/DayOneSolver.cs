using TaskSolvers.Common;

namespace TaskSolvers.Solvers
{
    public class DayOneSolver : ITaskSolver
    {
        private const int _dayNumber = 1;
        private const string _partOneFilePath = ".\\Resources\\DayOne\\PartOneInput.txt";

        public bool CanSolveTask(int dayNumber) => _dayNumber == dayNumber;

        public string SolvePartOne()
        {
            var input = GetPartOneInput();
            var count = 0;

            input.Aggregate((x, y) => {
                if (x < y)
                {
                    count++;
                }

                return y;
            });

            return count.ToString();
        }

        public string SolvePartTwo()
        {
            throw new NotImplementedException();
        }

        private List<int> GetPartOneInput()
        {
            var fileReader = new FileReader();
            return fileReader.ReadFileToListOfInts(_partOneFilePath);
        }
    }
}
