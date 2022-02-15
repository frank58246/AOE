using AOPExample.Core.Filters;

namespace AOPExample.Core.Validators
{
    public class SportValidator : ValidatorBase
    {
        [Profiling("SportValidator-Validate")]
        public override bool Validate(int countryCode)
        {
            return countryCode > 10;
        }
    }
}