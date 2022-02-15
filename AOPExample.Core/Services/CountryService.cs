using System.Collections.Generic;
using AOPExample.Core.Filters;
using AOPExample.Core.Models;
using AOPExample.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AOPExample.Core.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [Profiling("CountryService-Get")]
        public CountryModel Get(int code)
        {
            return this._countryRepository.Get(code);
        }

        [Log("CountryService-GetAll")]
        [Profiling("CountryService-GetAll")]
        public IEnumerable<CountryModel> GetAll(GetAllCountryRequest request)
        {
            return new List<CountryModel>()
            {
                new CountryModel()
                {
                    Code = 0,
                    Name = "TW"
                },
                new CountryModel()
                {
                    Code = 1,
                    Name = "SG"
                }
            };
            
        }
    }
}