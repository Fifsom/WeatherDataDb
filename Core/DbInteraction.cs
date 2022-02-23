using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using System.Globalization;

namespace Core
{
    public class DbInteraction
    {
        public static void PopulateDb()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            List<string[]> weatherValues = TextFileClean.RemoveDuplicates();

            HashSet<string> exceptions = new HashSet<string>();
            int validRowsCount = 0;
            int exceptionCount = 0;

            using (var context = new WeatherDataDbContext())
            {
                foreach (var value in weatherValues)
                {
                    WeatherDataModel model = new WeatherDataModel();
                    bool exception = false;

                    try
                    {
                        model.Datum = Convert.ToDateTime(value[0]);
                        model.Plats = Convert.ToString(value[1]);
                        model.Temp = Convert.ToDouble(value[2]);
                        model.Luftfuktighet = Convert.ToInt32(value[3]);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex.Message);
                        exception = true;
                        exceptionCount++;
                    }
                    if (exception == false)
                    {
                        try
                        {
                            context.Add(model);
                            validRowsCount++;
                        }
                        catch (Exception ex)
                        {
                            exceptions.Add(ex.Message);
                            exception = true;
                        }
                    }
                }
                context.SaveChanges();
            }
            DisplayMessages.ExceptionsCount(exceptionCount);
            DisplayMessages.ErrorMessages(exceptionCount, exceptions);
            DisplayMessages.ValidRowsCount(validRowsCount);


        }
        public static List<WeatherDataModel> GetAllDbRecords()
        {
            using (var context = new WeatherDataDbContext())
            {
                List<WeatherDataModel> weatherData = context.WeatherData.ToList();

                return weatherData;
            }
        }
    }
}
