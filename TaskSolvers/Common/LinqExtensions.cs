namespace TaskSolvers.Common
{
    internal static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<TSource>> BatchElements<TSource>(
                          this List<TSource> source, int batchSize)
        {
            TSource[] batch = null;
            var count = 0;
            var relativeIndex = 0;
            var underShoot = source.Count % batchSize;

            for (var index = 0; index < source.Count - underShoot; index++)
            {
                while (count != batchSize)
                {
                    if (batch == null)
                    {
                        batch = new TSource[batchSize];
                        batch[count++] = source[index];
                        relativeIndex = index + 1;
                    }

                    batch[count++] = source[relativeIndex];
                    relativeIndex++;
                }

                yield return batch;

                batch = null;
                count = 0;
            }
        }
    }
}
