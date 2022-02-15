using System.Collections.Generic;
using System.Linq;
using AOPExample.Core.Factories;
using AOPExample.Core.Filters;
using AOPExample.Core.Models;
using AOPExample.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AOPExample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GeoController: ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IValidatorFactory _validatorFactory;
        public GeoController(ICountryService countryService, IValidatorFactory validatorFactory)
        {
            _countryService = countryService;
            _validatorFactory = validatorFactory;
        }

        [HttpGet]
        public CountryModel GetCountry(int code)
        {
            return this._countryService.Get(code);
        }

        [HttpGet]
        public bool IsValidate(int code)
        {
            var validators = _validatorFactory.GetAllVadators();
            
            return validators.All(x => x.Validate(code));
        }

        [HttpPost]
        public IEnumerable<CountryModel> GetAll(GetAllCountryRequest request)
        {
            return _countryService.GetAll(request);
        }

    }
}