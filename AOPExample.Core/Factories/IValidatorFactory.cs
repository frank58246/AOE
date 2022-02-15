using System.Collections;
using System.Collections.Generic;
using AOPExample.Core.Validators;

namespace AOPExample.Core.Factories
{
    public interface IValidatorFactory
    {
        public IEnumerable<ValidatorBase> GetAllVadators();
    }
}