namespace TaskSolvers.Common
{
    internal class FileReader
    {
        public List<int> ReadFileToListOfInts(string path)
        {
            var outPut = new List<int>();

            try
            {
                var sr = new StreamReader(path);
                var line = sr.ReadLine();

                while (line != null)
                {
                    if (int.TryParse(line, out var number))
                    {
                        outPut.Add(number);
                    }

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }

            return outPut;
        }

        public List<string> ReadFileToListOfString(string path)
        {
            var outPut = new List<string>();

            try
            {
                var sr = new StreamReader(path);
                var line = sr.ReadLine();

                while (line != null)
                {
                    outPut.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }

            return outPut;
        }
    }
}
