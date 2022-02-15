using AOPExample.Core.Filters;

namespace AOPExample.Core.Validators
{
    public class GameValidator : ValidatorBase
    {
        [Profiling("GameValidator-Validate")]
        public override bool Validate(int countryCode)
        {
            return countryCode > 0;
        }
    };
}