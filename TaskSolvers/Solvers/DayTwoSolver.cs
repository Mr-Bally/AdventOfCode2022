using System.Text.RegularExpressions;
using TaskSolvers.Common;

namespace TaskSolvers.Solvers
{
    public class DayTwoSolver : ITaskSolver
    {
        private const int _dayNumber = 2;
        private const string _inputFilePath = ".\\Resources\\DayTwo\\Input.txt";

        private const char _forwardChar = 'f';
        private const char _upChar = 'u';
        private const char _downChar = 'd';
        
        public bool CanSolveTask(int dayNumber) => dayNumber == _dayNumber;
        
        public string SolvePartOne()
        {
            var input = GetInput();
            int forwardTotal = 0;
            int depthTotal = 0;

            foreach(var line in input)
            {
                switch(line[0])
                {
                    case _forwardChar:
                        forwardTotal += GetIntFromString(line);
                        break;

                    case _downChar:
                        depthTotal += GetIntFromString(line);
                        break;

                    case _upChar:
                        depthTotal -= GetIntFromString(line);
                        break;
                    default:
                        throw new Exception("Unknown char " + line[0]);
                }
            }

            return (forwardTotal * depthTotal).ToString();
        }

        public string SolvePartTwo()
        {
            throw new NotImplementedException();
        }
        
        private List<string> GetInput()
        {
            var fileReader = new FileReader();
            return fileReader.ReadFileToListOfString(_inputFilePath);
        }

        private int GetIntFromString(string line) => int.Parse(Regex.Match(line, @"\d+").Value);
    }
}
