using Flashcards.Entities;

namespace Flashcards.Repositories
{
    internal interface IFlashcardRepository
    {
        Task<List<Flashcard>> GetAllFlashcardsAsync(CancellationToken cancellationToken = default);
    }
}
