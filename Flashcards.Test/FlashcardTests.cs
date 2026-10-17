using Flashcards.Entities;
using Flashcards.Validation;

namespace Flashcards.Test
{
    public class FlashcardTests
    {

        //A flashcard with non-empty fron and back is valid
        //A flashcard with an empty front is invalid
        //A flashcard with an empty back is invalid
        //[Fact]

        //public bool FlashcardIsValid_WhenFrontAndBackAreProvided()
        //{

        //}
        [Fact]
        public async Task FlashcardIsInvalid_WhenFrontIsEmpty()
        {
            var flashcard = new Flashcard
            {
                Front = "",
                Back = "Dependency Injection"
            };


            var result = await FlashcardValidator.ValidateFlashcard(flashcard);

            Assert.False(result);
        }

        //public bool FlascardIsInvalid_WhenBackIsEmpty()
        //{

        //}
    }
}
