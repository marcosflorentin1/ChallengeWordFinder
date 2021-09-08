using ChallengeWordFinder.Models;

namespace ChallengeWordFinder.WordFinderValidator
{
    public interface IValidator
    {
        IValidator SetNext(IValidator handler);

        object Validate(ref ValidatorRequest request);
    }
}