using TaskSolvers.Common;

namespace TaskSolvers.Solvers
{
    public class DayOneSolver : ITaskSolver
    {
        private const int _dayNumber = 1;
        private const int _batchSize = 3;
        private const string _inputFilePath = ".\\Resources\\DayOne\\Input.txt";

        public bool CanSolveTask(int dayNumber) => _dayNumber == dayNumber;

        public string SolvePartOne()
        {
            return GetCountOfLargerInts(GetInput()).ToString();
        }

        public string SolvePartTwo()
        {
            var input = GetInput();
            var groupedInput = AddIntegersInGroups(input);

            return GetCountOfLargerInts(groupedInput).ToString();
        }

        private int GetCountOfLargerInts(IEnumerable<int> numbers)
        {
            var count = 0;

            numbers.Aggregate((x, y) => {
                if (x < y)
                {
                    count++;
                }

                return y;
            });

            return count;
        }

        private IEnumerable<int> AddIntegersInGroups(List<int> numbers)
        {
            var groupedElements = numbers.BatchElements(_batchSize);

            return groupedElements.Select(x => x.Sum());
        }

        private List<int> GetInput()
        {
            var fileReader = new FileReader();
            return fileReader.ReadFileToListOfInts(_inputFilePath);
        }
    }
}
