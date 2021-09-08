using ChallengeWordFinder.Models;

namespace ChallengeWordFinder.WordFinderValidator
{
    public abstract class AbstractValidator : IValidator
    {
        private IValidator _nextValidator;

        public IValidator SetNext(IValidator validator)
        {
            this._nextValidator = validator;

            return validator;
        }

        public virtual object Validate(ref ValidatorRequest request)
        {
            if (this._nextValidator != null)
            {
                return this._nextValidator.Validate(ref request);
            }
            else
            {
                return null;
            }
        }
    }
}
