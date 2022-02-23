using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Validate
    {
        public static bool IsDbEmpty()
        {
            var results = DbInteraction.GetAllDbRecords();

            if (results.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static WeatherDataModel DbInputData(WeatherDataModel model, List<string[]> value)
        {
            model.Datum = Convert.ToDateTime(value[0]);
            model.Plats = Convert.ToString(value[1]);
            model.Temp = Convert.ToDouble(value[2]);
            model.Luftfuktighet = Convert.ToInt32(value[3]);

            return model;
        }
    }
}
