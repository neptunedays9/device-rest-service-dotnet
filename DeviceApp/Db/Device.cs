namespace DeviceApp.api.lib.Db
{
    public class Device
    {
        public int Id { get; set; }
        
        public string Colour { get; set; }

        public string Model { get; set; }
        
        public decimal Price { get; set; }
        
        public int Year { get; set; }
        
        public string CountryManufactured { get; set; }
    }
}