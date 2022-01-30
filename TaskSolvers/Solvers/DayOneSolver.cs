using TaskSolvers.Common;

namespace TaskSolvers.Solvers
{
    public class DayOneSolver : BaseSolver
    {
        private const int _batchSize = 3;
        private const string _inputFilePath = ".\\Resources\\DayOne\\Input.txt";

        public override int DayNumber => 1;

        public override string SolvePartOne()
        {
            return GetCountOfLargerInts(GetInputAsListOfInts(_inputFilePath)).ToString();
        }

        public override string SolvePartTwo()
        {
            var input = GetInputAsListOfInts(_inputFilePath);
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
    }
}
