namespace Northwind.Controllers
{
    public class AbpBaseFilter
    {

        public string Filter { get; set; }
        public string Sort { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
