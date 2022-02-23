namespace Core
{
    public class TextFileClean
    {
        public static List<string[]> RemoveDuplicates()
        {
            string[] weatherValues = File.ReadAllLines("TempFuktData.csv");

            List<string> hasNoDuplicate = new List<string>();
            int duplicatesCounter = 0;

            for (int i = 1; i < weatherValues.Count(); i++)
            {
                for (int k = i + 1; k < weatherValues.Count(); k++)
                {
                    if (weatherValues[i] == weatherValues[k])
                    {
                        duplicatesCounter++;
                        break;
                    }
                    else
                    {
                        hasNoDuplicate.Add(weatherValues[i]);
                        break;
                    }
                }
            }

            List<string[]> listWithoutDuplicates = hasNoDuplicate
                .Skip(1)
                .Select(x => x.Split(','))
                .ToList();

            DisplayMessages.DuplicatesCount(duplicatesCounter);

            return listWithoutDuplicates;
        }
    }
}
