using System;
using AOPExample.Core.Models;

namespace AOPExample.Core.Repositories
{
    public class DecoCountryRepository:ICountryRepository
    {

        private readonly ICountryRepository _countryRepository;

        public DecoCountryRepository(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CountryModel Get(int code)
        {
            Console.WriteLine("Deco");
            return _countryRepository.Get(code);
        }
    }
}