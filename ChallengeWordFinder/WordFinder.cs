using System.Collections.Generic;
using System.Linq;
using ChallengeWordFinder.Models;
using ChallengeWordFinder.WordFinderValidator;

namespace ChallengeWordFinder
{
    public class WordFinder
    {
        private readonly string[] _matrix;
        private readonly RowRightValidator _rowRightValidator;
        private readonly ColumnDownValidator _columnDownValidator;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix.ToArray();
            _rowRightValidator = new RowRightValidator();
            _columnDownValidator = new ColumnDownValidator();
            //_columnUpValidator = new ColumnDownValidator();
            //_rowLeftValidator = new ColumnDownValidator();

            // Setting the order of validations
            _rowRightValidator
                .SetNext(_columnDownValidator);
            //.SetNext(_columnUpValidator);
            //.SetNext(_rowLeftValidator);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<string> result = new List<string>();
            Dictionary<string, int> repeatedWordCount = new Dictionary<string, int>();
            ValidatorRequest validatorRequest = new ValidatorRequest();
            char firstLetter;

            foreach (var word in wordstream)
            {
                firstLetter = word[0];

                //finding firstLetter in matrix
                for (int matrixLineIndex = 0; matrixLineIndex < _matrix.Length; matrixLineIndex++)
                {
                    for (int matrixLetterIndex = 0; matrixLetterIndex < _matrix[matrixLineIndex].Length; matrixLetterIndex++)
                    {
                        if (_matrix[matrixLineIndex][matrixLetterIndex] == firstLetter)
                        {
                            validatorRequest = new ValidatorRequest
                            {
                                Matrix = _matrix,
                                Word = word,
                                RepeatedWordCount = repeatedWordCount,
                                MatrixLineIndex = matrixLineIndex,
                                MatrixLetterIndex = matrixLetterIndex
                            };

                            _rowRightValidator.Validate(ref validatorRequest);
                        }
                    }
                }
            }

            return repeatedWordCount
                .OrderByDescending(key => key.Value)
                .Select(key => key.Key)
                .Take(10);
        }
    }
}
