namespace AOPExample.Core.Services
{
    public class GetAllCountryRequest
    {
        public int Language { get; set; }
        public string IP { get; set; }
        
        public override string ToString()
        {
            return $"Language: {Language}, IP: {IP}";
        }
    }
}