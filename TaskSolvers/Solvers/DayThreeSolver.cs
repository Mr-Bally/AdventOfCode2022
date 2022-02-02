namespace TaskSolvers.Solvers
{
    public class DayThreeSolver : BaseSolver
    {
        private const string _inputFilePath = ".\\Resources\\DayThree\\Input.txt";

        private const char _zeroChar = '0';
        private const char _oneChar = '1';
        private const int _baseNum = 2;

        public override int DayNumber => 3;

        public override string SolvePartOne()
        {
            var input = GetInputAsListOfStrings(_inputFilePath);
            var stringLength = input.First().Length;
            var gammaBinNum = new char[stringLength];

            for (var i = 0; i < stringLength; i++)
            {
                var columnOfChars = input.Select(x => x[i]);

                gammaBinNum[i] = IsOneMostCommonOrEqualBit(columnOfChars) ? _oneChar : _zeroChar;
            }

            return MultiplyCharBins(gammaBinNum, FlipBinChar(gammaBinNum)).ToString();
        }

        public override string SolvePartTwo()
        {
            var inputOne = GetInputAsListOfStrings(_inputFilePath);
            var inputTwo = new List<string>(inputOne);
            return (FindNumberInCollection(inputOne, true) * FindNumberInCollection(inputTwo, false))
                .ToString();
        }

        private char[] FlipBinChar(char[] binChars)
        {
            var toReturn = new char[binChars.Length];

            for (var x = 0; x < binChars.Length; x++)
            {
                if (binChars[x] == _zeroChar)
                {
                    toReturn[x] = _oneChar;
                }
                else
                {
                    toReturn[x] = _zeroChar;
                }
            }

            return toReturn;
        }

        private bool IsOneMostCommonOrEqualBit(IEnumerable<char> chars)
        {
            var zeroCount = chars.Count(x => x == _zeroChar);
            var oneCount = chars.Count(x => x == _oneChar);

            return oneCount >= zeroCount;
        }

        private int MultiplyCharBins(char[] arrayOne, char[] arrayTwo)
        {
            var arrayOneAsInt = Convert.ToInt32(new string(arrayOne), _baseNum);
            var arrayTwoAsInt = Convert.ToInt32(new string(arrayTwo), _baseNum);

            return arrayOneAsInt * arrayTwoAsInt;
        }

        private int FindNumberInCollection(List<string> input, bool takeMostPopular)
        {
            var found = false;
            var index = 0;
            int toReturn = 0;

            while (!found)
            {
                var columnOfChars = input.Select(x => x[index]);
                var isOneMostPopular = IsOneMostCommonOrEqualBit(columnOfChars);
                var charToRemove = GetCharToRemove(isOneMostPopular, takeMostPopular);
                input.RemoveAll(x => x[index] == charToRemove);

                if (input.Count == 1)
                {
                    toReturn = Convert.ToInt32(input.First(), _baseNum);
                    found = true;
                }

                index++;
            }

            return toReturn;
        }

        private char GetCharToRemove(bool isOneMostPopular, bool takeMostPopular)
        {
            if ((isOneMostPopular && !takeMostPopular) || (!isOneMostPopular && takeMostPopular))
            {
                return _zeroChar;
            }
            
            return _oneChar;
        }
    }
}
