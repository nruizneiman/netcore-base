namespace SP.Web.Api.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public byte[] Flag { get; set; }
        public string CurrencyCode { get; set; }
    }
}
