using AOPExample.Core.Models;

namespace AOPExample.Core.Repositories
{
    public interface ICountryRepository
    {
        public CountryModel Get(int code);
    }
}