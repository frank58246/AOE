using AOPExample.Core.Filters;
using AOPExample.Core.Models;
using AOPExample.Core.Services;

namespace AOPExample.Core.Repositories
{
    public class  CountryRepository:ICountryRepository
    {
        
        [Profiling("CountryRepository-Get")]
        public CountryModel Get(int code)
        {
            return new CountryModel()
            {
                Code = code,
                Name = "TW"
            };
        }
    }
}