using System.Collections.Generic;
using AOPExample.Core.Validators;

namespace AOPExample.Core.Factories
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IEnumerable<ValidatorBase> _validatorBases;

        public ValidatorFactory(IEnumerable<ValidatorBase> validatorBases)
        {
            _validatorBases = validatorBases;
        }

        public IEnumerable<ValidatorBase> GetAllVadators()
        {
            return _validatorBases;
        }
    }
}