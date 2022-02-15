using System.Collections;
using System.Collections.Generic;
using AOPExample.Core.Models;

namespace AOPExample.Core.Services
{
    public interface ICountryService
    {
        public CountryModel Get(int code);

        public IEnumerable<CountryModel> GetAll(GetAllCountryRequest request);
    }
}