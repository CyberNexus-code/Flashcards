using Flashcards.DTOs;
using Flashcards.Entities;
using Flashcards.Repositories;
using Flashcards.Validation;

namespace Flashcards.Services
{
    public class FlashcardService
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardService(FlashcardRepository flashcardRepository)
        {
            _flashcardRepository = flashcardRepository;
        }
        public async Task<List<Flashcard>> GetAllFlashcardsAsync(CancellationToken cancellationToken = default)
        {
            return await _flashcardRepository.GetAllFlashcardsAsync(cancellationToken);
        }



        public async Task<List<FlashcardDTO>> CreateFlashcardDTOs(List<Flashcard> flashcards)
        {
            var displayCards = new List<FlashcardDTO>();
            int index = 1;

            foreach (var flashcard in flashcards)
            {
                bool validFlashcard = await FlashcardValidator.ValidateFlashcard(flashcard);

                if (validFlashcard)
                {
                    var displayCard = new FlashcardDTO
                    {
                        Number = index,
                        Front = flashcard.Front,
                        Back = flashcard.Back,
                        StackId = flashcard.StackID
                    };

                    displayCards.Add(displayCard);
                }
            }

            return displayCards;
        }
    }
}
