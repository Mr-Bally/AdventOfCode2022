namespace TaskSolvers.Solvers
{
    public class DayTwoSolver : BaseSolver
    {
        private const string _inputFilePath = ".\\Resources\\DayTwo\\Input.txt";

        private const char _forwardChar = 'f';
        private const char _upChar = 'u';
        private const char _downChar = 'd';

        public override int DayNumber => 2;
        
        public override string SolvePartOne()
        {
            var input = GetInputAsListOfStrings(_inputFilePath);
            int forwardTotal = 0;
            int depthTotal = 0;

            foreach (var line in input)
            {
                var lineValue = GetIntFromString(line);

                switch (line[0])
                {
                    case _forwardChar:
                        forwardTotal += lineValue;
                        break;

                    case _downChar:
                        depthTotal += lineValue;
                        break;

                    case _upChar:
                        depthTotal -= lineValue;
                        break;
                    default:
                        throw new Exception("Unknown char " + line);
                }
            }

            return (forwardTotal * depthTotal).ToString();
        }

        public override string SolvePartTwo()
        {
            var input = GetInputAsListOfStrings(_inputFilePath);
            int forwardTotal = 0;
            int depthTotal = 0;
            int aimTotal = 0;

            foreach(var line in input)
            {
                var lineValue = GetIntFromString(line);

                switch(line[0])
                {
                    case _forwardChar:
                        forwardTotal += lineValue;
                        depthTotal += (lineValue * aimTotal);
                        break;

                    case _downChar:
                        aimTotal += lineValue;
                        break;

                    case _upChar:
                        aimTotal -= lineValue;
                        
                        if (aimTotal < 0)
                        {
                            aimTotal = 0;
                        }

                        break;
                    default:
                        throw new Exception("Unknown char " + line);
                }
            }

            return (forwardTotal * depthTotal).ToString();
        }
    }
}
