namespace DataAccessLibrary.Models
{

    public class WeatherDataModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Plats { get; set; }
        public double Temp { get; set; }
        public int Luftfuktighet { get; set; }
    }
}



