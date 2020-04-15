namespace SP.Service.DTOs.Country
{
    public class CountryDto : BaseDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public byte[] Flag { get; set; }
        public string CurrencyCode { get; set; }
    }
}
